CREATE PROCEDURE [dbo].[SP_Product_Update]
	@productId INT,
	@name VARCHAR(64),
	@description VARCHAR(512),
	@currentPrice MONEY,
	@userId UNIQUEIDENTIFIER
AS
BEGIN 
	UPDATE[Product]
		SET [Name] = @name,
			[Description] = @description,
			[CurrentPrice] = @currentPrice,
			[UserId] = @userId
			WHERE [ProductId] = @productId
END
