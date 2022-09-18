CREATE PROCEDURE [dbo].[spUpdateTask]
	@Task_Id int,
	@TaskName nvarchar(20),
	@TaskDescription nvarchar(25),
	@Priority nvarchar(10),
	@CreatedTime datetime,
	@IsCompleted bit
AS
	UPDATE ToDoTable SET 
	TaskName = @TaskName,
	TaskDescription = @TaskDescription,
	[Priority] = @Priority,
	CreatedTime = @CreatedTime,
	IsCompleted = @IsCompleted
GO
