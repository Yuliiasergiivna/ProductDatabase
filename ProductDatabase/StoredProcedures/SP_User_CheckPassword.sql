CREATE PROCEDURE [dbo].[SP_User_CheckPassword]
	@email NVARCHAR(320),
	@password VARBINARY(64)
AS
BEGIN
	SELECT [UserId]
	FROM [dbo].[User]
	WHERE [Email] = @email
		AND [Password] = @password;
END
