CREATE PROCEDURE [dbo].[SP_StockEntry_Get_All]

AS
BEGIN
	SELECT StockEntryId, EntryDate, StockOperation, ProductId, UserId
	FROM StockEntry;
END
