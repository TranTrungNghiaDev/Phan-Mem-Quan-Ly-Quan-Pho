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

EXEC USP_GetAccountByUserName @UserName = 'TranNghia98'
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

EXEC USP_Login @UserName = 'TranNghia98', @Password = '123456'
GO

DECLARE @i INT = 0;

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

UPDATE dbo.FoodTable
SET TableStatus = N'Có người'
WHERE Id = 7
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

-- Thêm Bill
INSERT INTO dbo.Bill
(DateCheckIn, DateCheckOut, FoodTableId, BillStatus)
VALUES
(GETDATE(), NULL, 1, 0),
(GETDATE(), NULL, 2, 0),
(GETDATE(), GETDATE(), 2, 1)
GO

-- Thêm bill info
INSERT INTO dbo.BillInfo
(BillId, FoodId, Quantity)
VALUES
(1, 1, 1),
(2, 3, 2),
(3, 4, 3)
GO

CREATE PROC USP_GetUnCheckBillByTableId
	@TableId INT
AS
BEGIN
SELECT *
FROM dbo.Bill
WHERE FoodTableId = @TableId AND BillStatus = 0
END
GO

CREATE PROC USP_GetListBillInfoByBillId 
	@BillId INT
AS
BEGIN
	SELECT *
	FROM dbo.BillInfo
	WHERE BillId = @BillId
END
GO

CREATE PROC USP_GetMenuByTableID
 @TableID INT
AS
BEGIN
SELECT b.Id, 
	f.FoodName, f.UnitPrice, 
	bf.Quantity,
	SUM (f.UnitPrice * bf.Quantity) AS [Total Price]
FROM dbo.Bill as b, dbo.Food as f, dbo.BillInfo as bf
WHERE b.Id = bf.Id AND f.Id = bf.FoodId AND b.Id = @TableID
GROUP BY b.Id, f.FoodName, f.UnitPrice, bf.Quantity
END
GO


EXEC 

EXEC 