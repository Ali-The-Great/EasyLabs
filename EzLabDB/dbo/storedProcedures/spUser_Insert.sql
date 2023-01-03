CREATE PROCEDURE [dbo].[spUser_Insert]
	@mail nvarchar(50),
    @salt nvarchar(50),
    @hash nvarchar(50),
    @phone_number nvarchar(50),
    @name nvarchar(50),
    @gender nvarchar(50) 
AS
Begin
	insert into dbo.[User] (mail,name,gender,phone_number,salt,hash) 
	values (@mail,@name,@gender,@phone_number,@salt,@hash)
RETURN 0
End
