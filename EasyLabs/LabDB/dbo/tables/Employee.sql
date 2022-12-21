CREATE TABLE Employee
(
	employee_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	user_id INT Foreign key REFERENCES [dbo].[User](user_id) on delete cascade NOT NULL, 
    employee_name NVARCHAR(50) NOT NULL, 
    employee_gender NVARCHAR(50) NOT NULL, 
    employee_phone_number NVARCHAR(50) NOT NULL,
	employee_birth_date date NOT NULL
)
