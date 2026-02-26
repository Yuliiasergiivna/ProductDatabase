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
--Table temporaire
CREATE TABLE #NewProducts (
    [Name] VARCHAR(64),
    [Description] VARCHAR(512),
    [CurrentPrice] MONEY
);
INSERT INTO #NewProducts ([Name], [Description], [CurrentPrice])
VALUES 
(N'Ordinateur Portable Dell',N'Ordinateur portable 15 pouces, 16GB RAM, SSD 512GB', 899.99),
(N'Souris Logitech MX Master 3',N'Souris sans fil ergonomique haute précision', 79.50),
(N'Clavier Mécanique Corsair', N'Clavier mécanique RGB avec switches Cherry MX Red', 129.99),
(N'Écran Samsung 27"', N'Moniteur 27 pouces 4K UHD IPS', 349.00),
(N'Disque Dur Externe 1TB', N'Disque dur externe USB 3.0 portable', 59.99),
(N'Casque Sony WH-1000XM5', N'Casque sans fil à réduction de bruit active', 399.90),
(N'Webcam Logitech C920', N'Webcam Full HD 1080p avec micro intégré', 89.99),
(N'Imprimante HP LaserJet', N'Imprimante laser monochrome rapide', 199.00),
(N'Tablette Apple iPad', N'iPad 10.9 pouces Wi-Fi 64GB', 579.00),
(N'Routeur TP-Link AX3000', N'Routeur Wi-Fi 6 double bande haute vitesse', 149.99);
--Sinchronisation de données
MERGE INTO [dbo].[Product] AS Target
USING #NewProducts AS Source
ON Target.[Name] = Source.[Name] --verifier le name
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Name], [Description], [CurrentPrice])
    VALUES (Source.[Name], Source.[Description], Source.[CurrentPrice])
WHEN MATCHED THEN
    UPDATE SET
        [Description]= Source.[Description],
        [CurrentPrice]= Source.[CurrentPrice];
DROP TABLE #NewProducts;

COMMIT TRANSACTION;
GO

--EXEC SP_Product_Insert N'Ordinateur Portable Dell',N'Ordinateur portable 15 pouces, 16GB RAM, SSD 512GB', 899.99;