IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkAssignmentVisibilityGroup')
	BEGIN
		DROP  Procedure  RemoveWorkAssignmentVisibilityGroup
	END

GO

CREATE Procedure [dbo].RemoveWorkAssignmentVisibilityGroup

	(
		@Id bigint
	)

AS
DELETE WorkAssignmentVisibilityGroup
WHERE 
	Id=@Id
GO
