CREATE TABLE Appointment
(
	appointment_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	client_id INT Foreign key REFERENCES [dbo].[Client](client_id) on delete cascade NOT NULL, 
    test_id INT Foreign key REFERENCES [dbo].[Test](test_id) NOT NULL,
	appointment_date date NOT NULL,
	appointment_time time NOT NULL
)