--Create the Library Database
CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

--Create the Users Table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(200) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('User', 'Admin')) NOT NULL
);
GO

--Create the Books Table
CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    Prise money,
    PublishedYear INT
);
GO

--Create the Reviews Table
CREATE TABLE Reviews (
    ReviewId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    BookId INT,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    ReviewText NVARCHAR(MAX),
    ReviewDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Review_User FOREIGN KEY (UserId) REFERENCES Users(UserId),
    CONSTRAINT FK_Review_Book FOREIGN KEY (BookId) REFERENCES Books(BookId)
);
GO
