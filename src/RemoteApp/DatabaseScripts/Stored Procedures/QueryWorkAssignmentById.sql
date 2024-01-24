IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentById')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkAssignmentById
	END
GO

CREATE Procedure dbo.QueryWorkAssignmentById
	(
	@Id varchar (100)
	)
AS

SELECT * FROM [WorkAssignment] WHERE Id=@Id
GO   

GRANT EXEC ON QueryWorkAssignmentById TO PUBLIC
GO