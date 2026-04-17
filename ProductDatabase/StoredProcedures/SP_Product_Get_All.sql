CREATE PROCEDURE [dbo].[SP_Product_Get_All]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ProductId],
			[Name], 
		   [Description], 
		   [CurrentPrice],
		   [UserId]
	FROM [dbo].[Product];		
END
GO
 