CREATE PROCEDURE [dbo].[spClient_Insert]
	@Client_Name nvarchar(50),
	@Client_gender nvarchar(50),
	@Client_Email nvarchar(50),
	@Client_phone_number nvarchar(50),
	@Client_birth_date date
AS
	insert into dbo.[Client] (user_id,client_name,client_gender,client_phone_number,client_gender) 
	values ((select user_id from dbo.[User] where email = @Client_Email) ,@Client_Name, @Client_gender, @Client_phone_number,@Client_birth_date)
RETURN 0
