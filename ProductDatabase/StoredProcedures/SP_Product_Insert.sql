CREATE PROCEDURE [dbo].[SP_Product_Insert]
	@name VARCHAR(64),
	@description VARCHAR(512),
	@currentPrice MONEY,
	@userId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	INSERT 
		INTO [dbo].[Product] (
		[Name], 
		[Description], 
		[CurrentPrice],
		[UserId])
		OUTPUT [Inserted].[ProductId]
		VALUES (
		@name, 
		@description, 
		@currentPrice,
		@userId);
END
GO
