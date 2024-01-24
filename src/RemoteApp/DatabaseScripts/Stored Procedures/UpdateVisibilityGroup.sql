IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateVisibilityGroup')
	BEGIN
		DROP PROCEDURE [dbo].UpdateVisibilityGroup
	END
GO

CREATE Procedure [dbo].UpdateVisibilityGroup
	(
		@Id [bigint],
		@Name VARCHAR(100)
	)
AS

UPDATE
	VisibilityGroup
SET
	Name = @Name
WHERE
	Id = @Id
GO

GRANT EXEC ON UpdateVisibilityGroup TO PUBLIC
GO