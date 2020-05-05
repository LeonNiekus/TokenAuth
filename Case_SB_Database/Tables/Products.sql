CREATE TABLE [dbo].[Products]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductName] VARCHAR(50) NOT NULL, 
    [ProductDescription] VARCHAR(255) NULL, 
    [ProductPrice] FLOAT NOT NULL,
)
