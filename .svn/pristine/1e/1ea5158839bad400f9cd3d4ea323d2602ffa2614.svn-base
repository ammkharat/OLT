 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateRestrictionLocationItem')
	BEGIN
		DROP  Procedure  UpdateRestrictionLocationItem
	END

GO


CREATE Procedure [dbo].UpdateRestrictionLocationItem
(
    @Id bigint,
    @Name varchar (50),
	@ParentItemId bigint = NULL,
    @FunctionalLocationId bigint = NULL
)
AS

UPDATE RestrictionLocationItem
SET	
	[Name] = @Name,
	[ParentItemId] = @ParentItemId,
	[FunctionalLocationId] = @FunctionalLocationId
WHERE Id = @Id
GO

GRANT EXEC ON UpdateRestrictionLocationItem TO PUBLIC
GO