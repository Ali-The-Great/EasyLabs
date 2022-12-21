CREATE TABLE Test_results
(
	result_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	appointment_id INT Foreign key REFERENCES [dbo].[Appointment](appointment_id) NOT NULL,
    component_id INT Foreign key REFERENCES [dbo].[Components](component_id) NOT NULL,
	result_value NVARCHAR(50) NOT NULL
)
