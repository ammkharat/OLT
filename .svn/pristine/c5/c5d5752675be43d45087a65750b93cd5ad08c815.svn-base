 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateRestrictionDefinitionLastInvokedDateTime')
	BEGIN
		DROP  Procedure  UpdateRestrictionDefinitionLastInvokedDateTime
	END

GO


CREATE Procedure [dbo].UpdateRestrictionDefinitionLastInvokedDateTime
(
    @id bigint,
    @LastInvokedDateTime datetime = NULL
)
AS

UPDATE RestrictionDefinition
SET	
	[LastInvokedDateTime] = @LastInvokedDateTime
WHERE ID = @id
GO

GRANT EXEC ON UpdateRestrictionDefinitionLastInvokedDateTime TO PUBLIC
GO