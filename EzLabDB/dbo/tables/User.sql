CREATE TABLE [dbo].[User]
(
	[user_Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [mail] NVARCHAR(50) NOT NULL, 
    [name] NVARCHAR(50) NOT NULL, 
    [gender] NVARCHAR(50) NOT NULL, 
    [phone_number] NVARCHAR(50) NOT NULL, 
    [salt] NVARCHAR(50) NOT NULL, 
    [hash] NVARCHAR(64) NOT NULL
)
