CREATE PROCEDURE [dbo].[SP_StockEntry_Get_ById]
	@productId INT

AS
BEGIN
	SELECT 
		[StockEntryId], 
		[EntryDate], 
		[StockOperation], 
		[ProductId]
	FROM 
		[dbo].[StockEntry]
	WHERE 
		[ProductId] = @productId
END