CREATE PROCEDURE [dbo].[spDeleteTaskById]
	@Task_Id int
AS
	DELETE FROM ToDoTable
	WHERE Task_Id = @Task_Id
GO
