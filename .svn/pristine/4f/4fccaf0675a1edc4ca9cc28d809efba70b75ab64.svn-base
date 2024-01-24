IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateWorkPermitMontrealGroup')
	BEGIN
		DROP PROCEDURE [dbo].UpdateWorkPermitMontrealGroup
	END
GO

CREATE Procedure [dbo].UpdateWorkPermitMontrealGroup
	(
		@Id [bigint],
		@Name VARCHAR(100),
		@DisplayOrder int
	)
AS

update WorkPermitMontrealGroup set Name = @Name, DisplayOrder = @DisplayOrder where Id = @Id
GO

GRANT EXEC ON UpdateWorkPermitMontrealGroup TO PUBLIC
GO