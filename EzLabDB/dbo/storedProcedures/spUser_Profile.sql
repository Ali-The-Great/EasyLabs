CREATE PROCEDURE [dbo].[spUser_Profile]
AS
BEGIN
    SELECT mail,name,phone_number,gender FROM dbo.[User]
RETURN 0
END
