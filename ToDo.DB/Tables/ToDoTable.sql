CREATE TABLE [dbo].[ToDoTable]
(
	[Task_Id] int IDENTITY(1,1) PRIMARY KEY,
	[TaskName] nvarchar(20),
	[TaskDescription] nvarchar(25),
	[CreatedTime] DateTime,
	[Priority] nvarchar(10),
	[IsCompleted] bit,
)