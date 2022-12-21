CREATE TABLE [dbo].[User]
(
	[user_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [email] NVARCHAR(50) NOT NULL, 
    [hash] NVARCHAR(50) NOT NULL, 
    [salt] NVARCHAR(50) NOT NULL
)
