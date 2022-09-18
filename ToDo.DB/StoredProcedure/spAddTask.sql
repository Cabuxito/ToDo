CREATE PROCEDURE [dbo].[spAddTask]
	@TaskName nvarchar(20),
	@TaskDescription nvarchar(25),
	@Priority nvarchar(10),
	@CreatedTime datetime

AS
	INSERT INTO ToDoTable (TaskName, TaskDescription, [Priority] , CreatedTime, IsCompleted)
	VALUES (@TaskName, @TaskDescription, @Priority, @CreatedTime, 0)
GO
