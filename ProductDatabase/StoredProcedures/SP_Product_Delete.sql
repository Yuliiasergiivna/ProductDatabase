CREATE PROCEDURE [dbo].[SP_Product_Delete]
	@productId INT

AS
BEGIN
	DELETE FROM [Product]
	WHERE [ProductId] = @productId
END
