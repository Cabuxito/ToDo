CREATE PROCEDURE [dbo].[spUpdateTask]
	@Task_Id int,
	@TaskName nvarchar(20),
	@TaskDescription nvarchar(25),
	@Priority nvarchar(10),
	@IsCompleted bit
AS
	UPDATE ToDoTable SET 
	TaskName = @TaskName,
	TaskDescription = @TaskDescription,
	[Priority] = @Priority,
	IsCompleted = @IsCompleted
	WHERE Task_Id = @Task_Id
GO
