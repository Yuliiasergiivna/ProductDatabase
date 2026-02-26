CREATE PROCEDURE [dbo].[SP_Product_Insert]
	@name VARCHAR(64),
	@description VARCHAR(512),
	@currentPrice MONEY
AS
BEGIN
	SET NOCOUNT ON;
	INSERT 
		INTO [dbo].[Product] (
		[Name], 
		[Description], 
		[CurrentPrice])
		OUTPUT [Inserted].[ProductId]
		VALUES (
		@name, 
		@description, 
		@currentPrice);
END
GO
