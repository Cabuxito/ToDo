CREATE PROCEDURE [dbo].[spDeleteAll]
	AS
	DELETE FROM ToDoTable 
	WHERE IsCompleted = 1
GO
