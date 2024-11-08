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