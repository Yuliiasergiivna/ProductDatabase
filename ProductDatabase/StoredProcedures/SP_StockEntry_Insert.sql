CREATE PROCEDURE [dbo].[SP_StockEntry_Insert]
	@entryDate DATETIME,
	@stockOperation INT,
	@productId INT
AS
BEGIN
	INSERT INTO [dbo].[StockEntry] (
		EntryDate, 
		StockOperation, 
		ProductId)
	VALUES (
		@entryDate, 
		@stockOperation, 
		@productId);
END
