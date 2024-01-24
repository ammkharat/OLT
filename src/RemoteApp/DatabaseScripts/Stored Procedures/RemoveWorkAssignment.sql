IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkAssignment')
	BEGIN
		DROP  Procedure  RemoveWorkAssignment
	END

GO

CREATE Procedure [dbo].RemoveWorkAssignment

	(
		@Id bigint
	)

AS
UPDATE WorkAssignment 
	SET DELETED = 1 
WHERE Id=@Id
GO
