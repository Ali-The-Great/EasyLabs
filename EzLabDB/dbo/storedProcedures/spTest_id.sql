CREATE PROCEDURE [dbo].[spTest_id]
AS
BEGIN
    SELECT test_type,test_id FROM dbo.[Test]
RETURN 0
END

