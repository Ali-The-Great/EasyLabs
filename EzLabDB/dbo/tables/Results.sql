CREATE TABLE [dbo].[Results]
(
	result_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	component_id INT Foreign key REFERENCES [dbo].[Components](component_id) NOT NULL,
	appointment_id INT Foreign key REFERENCES [dbo].[Appointment](appointment_id) NOT NULL,    
	[value] NVARCHAR(50) NOT NULL
)
