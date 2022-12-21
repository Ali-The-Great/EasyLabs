CREATE PROCEDURE [dbo].[spUser_Insert]
	@email nvarchar(50),
	@salt nvarchar(50),
	@hash nvarchar(50)
AS
Begin
	insert into dbo.[User] (email,salt,hash) 
	values (@email, @salt, @hash)
RETURN 0
End