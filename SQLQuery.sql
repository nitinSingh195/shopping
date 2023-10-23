USE [ShoppingCart]
GO

CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](100) NULL,
	[RegistrationDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[Role] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsActive]
GO


go
USE [ShoppingCart]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 20-10-2023 11.26.21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](255) NULL,
	[ProductImage] [nvarchar](255) NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[ProductPrice] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE Cart(
	cartId INT IDENTITY(1,1) NOT NULL,
	ProductId INT NOT NULL,
	UserId INT NOT NULL
) 
GO




go
create PROCEDURE [dbo].[CreateUser]
    @UserId INT OUTPUT,
    @Username NVARCHAR(50),
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @Email NVARCHAR(100),
    @PasswordHash NVARCHAR(100),
	@Role NVARCHAR(100)
AS
BEGIN
    
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
    BEGIN
       
        SET @UserId = -1; 
    END
    ELSE
    BEGIN
        INSERT INTO Users (Username, FirstName, LastName, Email, PasswordHash, RegistrationDate,Role)
        VALUES (@Username, @FirstName, @LastName, @Email, @PasswordHash, GETDATE(), @Role);
        SET @UserId = SCOPE_IDENTITY();
    END
END
go
create PROCEDURE [dbo].[GetProducts]
AS
BEGIN
    SELECT
        ProductId,
        ProductName,
        ProductImage,
        ProductDescription,
        ProductPrice,
        (ProductPrice * 0.8) AS DiscountedPrice
    FROM
        Products; 
END
go

alter  PROCEDURE [dbo].[loginsp]
    @Username NVARCHAR(255),
    
    @PasswordHash NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Users

        WHERE Username = @Username  AND PasswordHash = @PasswordHash
    )
    BEGIN
       
       SELECT UserID
        FROM Users
    END
    ELSE
    BEGIN
        SELECT 0;
    END
END;
go
 create PROCEDURE [dbo].[usersrole]
    @Username VARCHAR(20),
    @Role VARCHAR(20) OUTPUT
AS
BEGIN
    SELECT @Role = Role
    FROM Users
    WHERE Username = @Username;
END



