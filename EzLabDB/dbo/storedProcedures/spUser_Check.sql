CREATE PROCEDURE [dbo].[spUser_Check]
AS
BEGIN
    SELECT mail,salt,hash FROM dbo.[User]
RETURN 0
END
