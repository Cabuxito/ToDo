CREATE PROCEDURE [dbo].[spUpdateTask]
	@Task_Id int,
	@TaskName nvarchar(20),
	@TaskDescription nvarchar(25),
	@Priority nvarchar(10)
AS
	UPDATE ToDoTable SET 
	TaskName = @TaskName,
	TaskDescription = @TaskDescription,
	[Priority] = @Priority
	WHERE Task_Id = @Task_Id
GO
