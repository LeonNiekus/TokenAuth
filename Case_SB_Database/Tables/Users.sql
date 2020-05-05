CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] VARCHAR(50) NOT NULL, 
    [UserPassword] VARCHAR(50) NOT NULL, 
    [UserRole] VARCHAR(50) NOT NULL, 
    [UserEmail] VARCHAR(100) NOT NULL
)
