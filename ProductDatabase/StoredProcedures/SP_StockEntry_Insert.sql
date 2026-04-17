CREATE PROCEDURE [dbo].[SP_StockEntry_Insert]
	@entryDate DATETIME,
	@stockOperation INT,
	@productId INT,
	@userId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[StockEntry] (
		EntryDate, 
		StockOperation, 
		ProductId,
		UserId)
	VALUES (
		@entryDate, 
		@stockOperation, 
		@productId,
		@userId);
END
