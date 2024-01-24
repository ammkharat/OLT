IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveVisibilityGroup')
	BEGIN
		DROP PROCEDURE [dbo].RemoveVisibilityGroup
	END
GO

CREATE Procedure [dbo].RemoveVisibilityGroup
	(
		@Id [bigint]
	)
AS

UPDATE
	VisibilityGroup
SET
	Deleted = 1
WHERE
	Id = @Id
GO

GRANT EXEC ON RemoveVisibilityGroup TO PUBLIC
GO