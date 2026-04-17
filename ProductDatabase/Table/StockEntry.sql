CREATE TABLE [dbo].[StockEntry]
(
	[StockEntryId] INT NOT NULL PRIMARY KEY IDENTITY,
    [EntryDate] DATETIME NOT NULL, 
    [StockOperation] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_StockEntry_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId]), 
    CONSTRAINT [FK_StockEntry_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
);
