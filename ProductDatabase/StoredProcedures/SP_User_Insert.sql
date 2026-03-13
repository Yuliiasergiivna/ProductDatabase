CREATE PROCEDURE [dbo].[SP_User_Insert]
	@email NVARCHAR(320),
	@password VARBINARY(64)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @salt UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [dbo].[User] ([Email], [Password], [Salt])
	OUTPUT INSERTED.[UserId]
	VALUES (@email, @password, @salt);
END