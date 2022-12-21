CREATE TABLE Components
(
	component_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	test_id INT Foreign key REFERENCES [dbo].[Test](test_id) NOT NULL,
	unit_id INT Foreign key REFERENCES [dbo].[Units](unit_id) NOT NULL,
    component_description NVARCHAR(50) NOT NULL,
	m_average NVARCHAR(50) NOT NULL,
	f_average NVARCHAR(50) NOT NULL
)
