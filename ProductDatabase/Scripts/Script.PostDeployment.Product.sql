/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--SET XACT_ABORT ON;--s'il y aun errore, return
BEGIN TRANSACTION;
DECLARE @MyUserId UNIQUEIDENTIFIER = '00000000-0000-0000-0000-000000000001';
MERGE INTO [dbo].[User] AS Target
USING (VALUES(@MyUserId, N'yuliia@gmail.com', 0x010203, NEWID()))
AS Source ([UserId],[Email],[Password],[Salt])
ON (Target.[Email] = Source.[Email])
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([UserId], [Email], [Password], [Salt])
    VALUES (Source.[UserId], Source.[Email], Source.[Password], Source.[Salt]);
--Table temporaire
CREATE TABLE #NewProducts (
    [Name] VARCHAR(64),
    [Description] VARCHAR(512),
    [CurrentPrice] MONEY,
    [UserId] UNIQUEIDENTIFIER
);
INSERT INTO #NewProducts ([Name], [Description], [CurrentPrice],[UserId])
VALUES 
(N'Ordinateur Portable Dell',N'Ordinateur portable 15 pouces, 16GB RAM, SSD 512GB', 899.99,@MyUserId),
(N'Souris Logitech MX Master 3',N'Souris sans fil ergonomique haute précision', 79.50, @MyUserId),
(N'Clavier Mécanique Corsair', N'Clavier mécanique RGB avec switches Cherry MX Red', 129.99, @MyUserId),
(N'Écran Samsung 27"', N'Moniteur 27 pouces 4K UHD IPS', 349.00, @MyUserId),
(N'Disque Dur Externe 1TB', N'Disque dur externe USB 3.0 portable', 59.99, @MyUserId),
(N'Casque Sony WH-1000XM5', N'Casque sans fil à réduction de bruit active', 399.90, @MyUserId),
(N'Webcam Logitech C920', N'Webcam Full HD 1080p avec micro intégré', 89.99, @MyUserId),
(N'Imprimante HP LaserJet', N'Imprimante laser monochrome rapide', 199.00, @MyUserId),
(N'Tablette Apple iPad', N'iPad 10.9 pouces Wi-Fi 64GB', 579.00, @MyUserId),
(N'Routeur TP-Link AX3000', N'Routeur Wi-Fi 6 double bande haute vitesse', 149.99, @MyUserId);
--Sinchronisation de données
MERGE INTO [dbo].[Product] AS Target
USING #NewProducts AS Source
ON Target.[Name] = Source.[Name] 
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Name], [Description], [CurrentPrice],[UserId])
    VALUES (Source.[Name], Source.[Description], Source.[CurrentPrice], Source.[UserId])
WHEN MATCHED THEN
    UPDATE SET
        [Description]= Source.[Description],
        [CurrentPrice]= Source.[CurrentPrice],
        [UserId] = Source.[UserId];
DROP TABLE #NewProducts;
IF NOT EXISTS (SELECT 1 FROM [StockEntry] WHERE [UserId] = @MyUserId)
BEGIN
    INSERT INTO [dbo].[StockEntry] ([EntryDate], [StockOperation], [ProductId], [UserId])
    VALUES (GETDATE(), 10, (SELECT TOP 1 ProductId FROM Product WHERE Name = N'Ordinateur Portable Dell'), @MyUserId);
END

COMMIT TRANSACTION;
GO
