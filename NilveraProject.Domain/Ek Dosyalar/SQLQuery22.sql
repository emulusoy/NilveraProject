CREATE DATABASE [NilveraDatabase];
GO
USE [NilveraDatabase];
GO

IF OBJECT_ID('dbo.Customers') IS NULL
BEGIN
    CREATE TABLE dbo.Customers
    (
        Id        INT IDENTITY(1,1) PRIMARY KEY,
        Name      NVARCHAR(100) NOT NULL,
        Surname   NVARCHAR(100) NOT NULL,
        Email     NVARCHAR(200) NULL,
        Phone     NVARCHAR(50)  NULL,
        Address   NVARCHAR(300) NULL,
        JsonData  NVARCHAR(MAX) NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        UpdatedAt DATETIME2 NULL
    );
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_Customers_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, Surname, Email, Phone, Address, JsonData
    FROM dbo.Customers
    ORDER BY Id DESC;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_Customers_GetById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, Surname, Email, Phone, Address, JsonData
    FROM dbo.Customers WHERE Id = @Id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_Customers_Insert
    @Name NVARCHAR(100),
    @Surname NVARCHAR(100),
    @Email NVARCHAR(200) = NULL,
    @Phone NVARCHAR(50) = NULL,
    @Address NVARCHAR(300) = NULL,
    @JsonData NVARCHAR(MAX) = NULL,
    @NewId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Customers(Name,Surname,Email,Phone,Address,JsonData,CreatedAt)
    VALUES (@Name,@Surname,@Email,@Phone,@Address,@JsonData,SYSUTCDATETIME());

    SET @NewId = SCOPE_IDENTITY();
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_Customers_Update
    @Id INT,
    @Name NVARCHAR(100),
    @Surname NVARCHAR(100),
    @Email NVARCHAR(200) = NULL,
    @Phone NVARCHAR(50) = NULL,
    @Address NVARCHAR(300) = NULL,
    @JsonData NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Customers
    SET Name = @Name,
        Surname = @Surname,
        Email = @Email,
        Phone = @Phone,
        Address = @Address,
        JsonData = @JsonData,
        UpdatedAt = SYSUTCDATETIME()
    WHERE Id = @Id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_Customers_Delete
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Customers WHERE Id = @Id;
END
GO
