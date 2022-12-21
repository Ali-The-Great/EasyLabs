CREATE TABLE Client
(
	client_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	user_id INT Foreign key REFERENCES [dbo].[User](user_id) on delete cascade NOT NULL, 
    client_name NVARCHAR(50) NOT NULL, 
    client_gender NVARCHAR(50) NOT NULL, 
    client_phone_number NVARCHAR(50) NOT NULL,
	client_birth_date date NOT NULL
)
