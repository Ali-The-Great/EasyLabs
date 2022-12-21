CREATE PROCEDURE [dbo].[spEmp_Insert]
	@Employee_Name nvarchar(50),
	@Employee_gender nvarchar(50),
	@Employee_Email nvarchar(50),
	@Employee_phone_number nvarchar(50),
	@Employee_birth_date date
AS
	insert into dbo.[Employee] (user_id,Employee_name,Employee_gender,Employee_phone_number,Employee_gender) 
	values ((select user_id from dbo.[User] where email = @Employee_Email) ,@Employee_Name, @Employee_gender, @Employee_phone_number,@Employee_birth_date)
RETURN 0
