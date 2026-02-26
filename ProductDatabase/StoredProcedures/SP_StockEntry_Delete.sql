CREATE PROCEDURE [dbo].[SP_StockEntry_Delete]
	@productId INT

AS
BEGIN
	DELETE FROM 
		[dbo].[StockEntry]
	WHERE 
		[ProductId] = @productId
END