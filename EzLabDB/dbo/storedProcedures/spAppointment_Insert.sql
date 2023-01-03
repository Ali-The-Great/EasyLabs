CREATE PROCEDURE [dbo].[spAppointment_Insert]
    @user_id int,
    @test_id int,
    @appointment_date date,
    @appointment_time time(7)

AS
Begin
	insert into dbo.[Appointment] (user_id ,test_id,appointment_date,appointment_time) 
	values (@user_id ,@test_id,@appointment_date,@appointment_time)
RETURN 0
End
