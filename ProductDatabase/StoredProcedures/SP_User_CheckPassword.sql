CREATE PROCEDURE [dbo].[SP_User_CheckPassword]
	@email NVARCHAR(320),
	@password NVARCHAR(64)
AS
BEGIN
	SET NOCOUNT ON
	SELECT [UserId]
	FROM [dbo].[User]
	WHERE [Email] = @email
		AND [Password] = [dbo].[SF_SaltAndHash]( @password, [salt]);
END
