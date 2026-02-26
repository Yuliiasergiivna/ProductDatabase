CREATE PROCEDURE [dbo].[SP_Product_Update]
	@productId INT,
	@name VARCHAR(64),
	@description VARCHAR(512),
	@currentPrice MONEY
AS
BEGIN 
	UPDATE[Product]
		SET [Name] = @name,
			[Description] = @description,
			[CurrentPrice] = @currentPrice
			WHERE [ProductId] = @productId
END
