CREATE PROCEDURE [dbo].[SP_Product_Get_ById]
	@productId INT

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ProductId],
			[Name],
			[Description],
			[CurrentPrice]
	FROM [dbo].[Product]
	WHERE [ProductId] = @productId
END
GO
