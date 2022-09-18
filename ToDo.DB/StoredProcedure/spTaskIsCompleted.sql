CREATE PROCEDURE [dbo].[spTaskIsCompleted]
	@Task_Id int
AS
	UPDATE ToDoTable SET
	IsCompleted = 1
	WHERE Task_Id = @Task_Id
GO
