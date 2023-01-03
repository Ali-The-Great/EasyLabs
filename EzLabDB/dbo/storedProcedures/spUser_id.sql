CREATE PROCEDURE [dbo].[spUser_id]
AS
BEGIN
    SELECT mail,user_Id FROM dbo.[User]
RETURN 0
END
