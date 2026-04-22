CREATE PROCEDURE [dbo].[SP_User_Insert]
	@email NVARCHAR(320),
	@password NVARCHAR(64)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @salt UNIQUEIDENTIFIER = NEWID()
	INSERT INTO [dbo].[User] ([Email], [Password], [Salt])
	OUTPUT [inserted].[UserId]
	VALUES (@email,[dbo].[SF_SaltAndHash]( @password, @salt), @salt)
END