CREATE DATABASE QuanLyQuanPho
GO

USE QuanLyQuanPho
Go

-- Food
-- Table Food
-- Food Category
-- Account
-- Bill
-- Bill Info

-- Table Food
CREATE TABLE FoodTable
(
	Id INT IDENTITY PRIMARY KEY,
	TableName NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa đặt tên',
	TableStatus NVARCHAR(100) NOT NULL DEFAULT N'Trống' -- Trống | Có người
)
GO

-- Account Table
CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,
	UserPassword NVARCHAR(1000) NOT NULL DEFAULT 0,
	DisplayName NVARCHAR(100) NOT NULL  DEFAULT 'NTPho',
	AccountType INT NOT NULL DEFAULT 0 -- 1 là Admin, 0 là staff
)
GO

-- Food Category Table
CREATE TABLE FoodCategory
(
	Id INT IDENTITY PRIMARY KEY,
	CategoryName NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

-- Food Table
CREATE TABLE Food
(
	Id INT IDENTITY PRIMARY KEY,
	FoodName NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	CategoryId INT NOT NULL,
	UnitPrice FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (CategoryId) REFERENCES dbo.FoodCategory(Id)
)
GO

-- Bill Table
CREATE TABLE Bill
(
	Id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	FoodTableId INT NOT NULL,
	BillStatus INT NOT NULL DEFAULT 0, -- 1 là đã thanh toán , 0 là chưa thanh toán
	Discount INT NOT NULL DEFAULT 0,

	FOREIGN KEY (FoodTableId) REFERENCES dbo.FoodTable(Id)
)
GO

-- Bill Info
CREATE TABLE BillInfo
(
	Id INT IDENTITY PRIMARY KEY,
	BillId INT NOT NULL,
	FoodId INT NOT NULL,
	Quantity INT NOT NULL DEFAULT 0

	FOREIGN KEY (BillId) REFERENCES dbo.Bill(Id),
	FOREIGN KEY (FoodId) REFERENCES dbo.Food(Id)
)
GO

INSERT INTO dbo.Account (UserName, UserPassword, DisplayName, AccountType)
VALUES (N'TranNghia98',N'123456',N'Nghia', 1),
(N'NguyenNgan',N'456789', N'Ngan', 0)
GO

CREATE PROC USP_GetAccountByUserName 
@UserName NVARCHAR(100)
AS
BEGIN
	SELECT *
	FROM dbo.Account
	WHERE UserName = @UserName
END
GO

CREATE PROC USP_Login
@UserName NVARCHAR(100),
@Password NVARCHAR(100)
AS
BEGIN
	SELECT *
	FROM dbo.Account
	WHERE UserName = @UserName AND UserPassword = @Password
END
GO

DECLARE @i INT = 1;

WHILE @i < 10
BEGIN
	INSERT INTO dbo.FoodTable(TableName)
	VALUES (N'Bàn ' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
GO

CREATE PROC USP_GetFoodTableList
AS
BEGIN
	SELECT * 
	FROM dbo.FoodTable
END
GO

-- FoodTable
-- Bill
-- Bill Info
-- Food
-- Category

-- Thêm Category
INSERT INTO dbo.FoodCategory
(CategoryName)
VALUES(N'Đồ ăn'), (N'Đồ uống')
GO 

-- Thêm Food
INSERT INTO dbo.Food
	(FoodName, CategoryId, UnitPrice)
VALUES
-- Món ăn
(N'Phở tái / chín', 1, 35000),
(N'Phở sốt vang', 1, 35000),
(N'Phở thập cẩm', 1, 35000),
(N'Phở nạm gầu', 1, 40000),
(N'Phở bắp bò', 1, 50000),
-- Đồ uống
(N'Trà đá', 2, 5000),
(N'Sữa đậu', 2, 7000),
(N'Coca', 2, 10000),
(N'Pepsi', 2, 10000)
GO

-- Lấy hóa đơn chưa thanh toán theo Table ID
CREATE PROC USP_GetUnCheckBillByTableId
	@TableId INT
AS
BEGIN
SELECT *
FROM dbo.Bill
WHERE FoodTableId = @TableId AND BillStatus = 0
END
GO

-- Lấy danh sách BillInfo theo BillID
CREATE PROC USP_GetListBillInfoByBillId 
	@BillId INT
AS
BEGIN
	SELECT *
	FROM dbo.BillInfo
	WHERE BillId = @BillId
END
GO

-- Lấy danh sách Menu dựa theo TableID
CREATE PROC USP_GetMenuByTableID
 @TableID INT
AS
BEGIN
SELECT f.FoodName, f.UnitPrice, bf.Quantity,
	(f.UnitPrice * bf.Quantity * (1 - b.Discount)) AS [Total Price]
FROM dbo.Bill as b, dbo.BillInfo as bf, 
	dbo.Food as f, dbo.FoodTable as ft
WHERE b.Id = bf.BillId AND f.Id = bf.FoodId 
AND ft.Id = b.FoodTableId 
AND ft.Id = @TableID
AND b.BillStatus = 0
END
GO

-- Lấy danh sách FoodCategory
CREATE PROC USP_GetListFoodCategory
AS
BEGIN
	SELECT *
	FROM dbo.FoodCategory
END
GO

-- Lấy danh sách Food dựa theo Category ID
CREATE PROC USP_GetListFoodByCategoryId
 @CategoryId INT
AS
BEGIN
	SELECT *
	FROM dbo.Food
	WHERE CategoryId = @CategoryId
END
GO

-- Thêm hóa đơn chưa thanh toán dựa theo Table ID
CREATE PROC USP_CreateUncheckBillByTableID
	@TableID INT
AS
BEGIN
	INSERT INTO dbo.Bill (FoodTableId, Discount)
	VALUES(@TableID, 0)
END
GO

-- Lấy ra id mới nhất của Bill Table
CREATE PROC USP_GetLastestBillId
AS
BEGIN
	SELECT MAX(Id)
	FROM dbo.Bill
END
GO

-- Tạo ra Bill Info dựa theo Food ID
CREATE PROC USP_CreateBillInfoByBillAndFoodId
	@BillId INT, 
	@FoodID INT,
	@Quantity INT
AS
BEGIN
	DECLARE @isBillInfoExist INT
	DECLARE @foodQuantity INT = 0

	SELECT @isBillInfoExist = bf.Id,
		@foodQuantity = bf.Quantity
	FROM dbo.BillInfo as bf, dbo.Bill as b
	WHERE b.Id = bf.BillId
	AND bf.BillId = @BillId 
	AND bf.FoodId = @FoodID
	AND b.BillStatus = 0

	IF(@isBillInfoExist > 0)
	BEGIN
		DECLARE @newQuantity INT = @foodQuantity + @Quantity
		IF(@newQuantity > 0)
		BEGIN
			UPDATE dbo.BillInfo
			SET Quantity = @foodQuantity + @Quantity
			WHERE BillId = @BillId AND FoodId = @FoodID
		END

		ELSE
		BEGIN
			DELETE dbo.BillInfo
			WHERE BillId = @BillId AND FoodId = @FoodID
		END
	END

	ELSE
	BEGIN
		INSERT INTO dbo.BillInfo (BillId, FoodId, Quantity)
		VALUES (@BillId, @FoodID, @Quantity)
	END
	
END
GO

-- Thanh toán hóa đơn dựa theo BillID
CREATE PROC USP_CheckOutBillByBillID
@BillID INT,
@Discount INT
AS
BEGIN
	UPDATE dbo.Bill
	SET BillStatus = 1,
	DateCheckOut = GETDATE(),
	Discount = @Discount
	WHERE Id = @BillID
END
GO

-- Tạo Trigger cho Bill Info
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @BillID INT
	SELECT @BillID = BillID 
	FROM inserted

	DECLARE @TableID INT
	SELECT @TableID = FoodTableId 
	FROM dbo.Bill
	WHERE Id = @BillID AND BillStatus = 0

	UPDATE dbo.FoodTable
	SET TableStatus = N'Có người'
	WHERE Id = @TableID
END
GO

-- Tạo Trigger cho Bill
CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	UPDATE dbo.FoodTable
	SET TableStatus = N'Có người'
	WHERE Id IN (
		SELECT FoodTableId
		FROM dbo.Bill
		WHERE BillStatus = 0
	)

	UPDATE dbo.FoodTable
	SET TableStatus = N'Trống'
	WHERE Id NOT IN (
		SELECT FoodTableId
		FROM dbo.Bill
		WHERE BillStatus = 0
	)
END
GO

-- Đổi Bill giữa 2 bàn
CREATE PROC USP_SwitchBillByTableId
	@firstTableID INT,
	@secondTableID INT
AS
BEGIN
	-- Lấy ID bill của bàn đầu tiên
	DECLARE @firstTableBill INT
	BEGIN
		SELECT @firstTableBill = Id
		FROM dbo.Bill
		WHERE FoodTableId = @firstTableID 
			AND BillStatus = 0
	END
	-- Lấy ID bill của bàn thứ hai
	DECLARE @secondTableBill INT
	BEGIN
		SELECT @secondTableBill = Id
		FROM dbo.Bill
		WHERE FoodTableId = @secondTableID 
			AND BillStatus = 0
	END

	-- Hoán đổi hóa đơn giữa 2 bàn
	-- TH1: Nếu 1 trong 2 hóa đơn bị NULL
	IF(@firstTableBill IS NOT NULL AND @secondTableBill IS NULL)
		BEGIN
			UPDATE dbo.Bill
			SET FoodTableId = @secondTableID
			WHERE Id = @firstTableBill
		END

	ELSE IF(@secondTableBill IS NOT NULL AND @firstTableBill IS NULL)
		BEGIN
			UPDATE dbo.Bill
			SET FoodTableId = @firstTableID
			WHERE Id = @secondTableBill
		END

	ELSE IF(@firstTableBill IS NOT NULL AND @secondTableBill IS NOT NULL)
		BEGIN
			UPDATE dbo.Bill
			SET FoodTableId = @secondTableID
			WHERE Id = @firstTableBill

			UPDATE dbo.Bill
			SET FoodTableId = @firstTableID
			WHERE Id = @secondTableBill
		END
END
GO

-- Gộp Bill giữa 2 bàn
ALTER PROC USP_MergeBillByTableId
	@firstTableID INT,
	@secondTableID INT
AS
BEGIN
	-- Lấy ID bill của bàn đầu tiên
	DECLARE @firstTableBill INT
	BEGIN
		SELECT @firstTableBill = Id
		FROM dbo.Bill
		WHERE FoodTableId = @firstTableID 
			AND BillStatus = 0
	END
	-- Lấy ID bill của bàn thứ hai
	DECLARE @secondTableBill INT
	BEGIN
		SELECT @secondTableBill = Id
		FROM dbo.Bill
		WHERE FoodTableId = @secondTableID 
			AND BillStatus = 0
	END

	-- Hoán đổi hóa đơn giữa 2 bàn
	-- TH1: Nếu 1 trong 2 hóa đơn bị NULL
	IF(@firstTableBill IS NOT NULL AND @secondTableBill IS NULL)
		BEGIN
			UPDATE dbo.Bill
			SET FoodTableId = @secondTableID
			WHERE Id = @firstTableBill
		END

	ELSE IF(@secondTableBill IS NOT NULL AND @firstTableBill IS NULL)
		BEGIN
			UPDATE dbo.Bill
			SET FoodTableId = @firstTableID
			WHERE Id = @secondTableBill
		END

	-- TH2: Nếu cả 2 hóa đơn không bị NULL
	ELSE IF(@secondTableBill IS NOT NULL AND @firstTableBill IS NOT NULL)
		BEGIN
		-- Lấy danh sách bill info ở hóa đơn của bàn thứ 2
		-- Chuyển danh sách này sang bill bàn 1
		-- Chuyển Bill bàn 2 thành đã thanh toán
			UPDATE BillInfo
			SET BillId = @firstTableBill
			WHERE Id IN (		
				SELECT Id
				FROM dbo.BillInfo
				WHERE BillId = @secondTableBill
			)

			UPDATE Bill
			SET BillStatus = 1
			WHERE Id = @secondTableBill
		END
	END
GO

