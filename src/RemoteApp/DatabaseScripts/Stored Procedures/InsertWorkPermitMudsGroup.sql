
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMudsGroup')
	BEGIN
		DROP Procedure [dbo].InsertWorkPermitMudsGroup
	END
GO

CREATE Procedure [dbo].[InsertWorkPermitMudsGroup]
	(
	@Id bigint Output,
	@Name varchar(100),
	@DisplayOrder int
	)
AS

INSERT INTO WorkPermitMudsGroup ([Name], DisplayOrder, Deleted)
VALUES (@Name, @DisplayOrder, 0)

SET @Id= SCOPE_IDENTITY()
GO


GRANT EXEC ON InsertWorkPermitMudsGroup TO PUBLIC
GO
