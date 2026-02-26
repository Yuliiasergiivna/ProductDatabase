CREATE TABLE [dbo].[Product]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(64) NOT NULL, 
    [Description] VARCHAR(512) NULL, 
    [CurrentPrice] MONEY NOT NULL
)
