CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(100) NULL,
    RegistrationDate DATETIME NULL,
    LastLoginDate DATETIME,
    IsActive BIT NOT NULL default 1 
);
go
