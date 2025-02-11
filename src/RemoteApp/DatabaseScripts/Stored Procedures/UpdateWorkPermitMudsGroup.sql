
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateWorkPermitMudsGroup')
	BEGIN
		DROP Procedure [dbo].UpdateWorkPermitMudsGroup
	END
GO

CREATE Procedure [dbo].[UpdateWorkPermitMudsGroup]
	(
		@Id [bigint],
		@Name VARCHAR(100),
		@DisplayOrder int
	)
AS

update WorkPermitMudsGroup set Name = @Name, DisplayOrder = @DisplayOrder where Id = @Id
GO

GRANT EXEC ON UpdateWorkPermitMudsGroup TO PUBLIC
GO
