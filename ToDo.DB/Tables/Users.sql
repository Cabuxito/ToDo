CREATE TABLE [dbo].[Users]
(
	[User_Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Username] nvarchar(50),
	[Password] nvarchar(50),
	[FirstName] nvarchar(20),
	[LastName] nvarchar(20),
)
