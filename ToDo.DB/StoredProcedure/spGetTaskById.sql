CREATE PROCEDURE [dbo].[spGetTaskById]
	@Task_Id int
AS
	SELECT * FROM ToDoTable WHERE Task_Id = @Task_Id
GO
