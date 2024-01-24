-- Drop the old proc
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountActionItemDefinitionsByName')
	BEGIN
		DROP PROCEDURE [dbo].CountActionItemDefinitionsByName
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountSAPSourcedActionItemDefinitionsByName')
	BEGIN
		DROP PROCEDURE [dbo].CountSAPSourcedActionItemDefinitionsByName
	END
GO

CREATE Procedure [dbo].CountSAPSourcedActionItemDefinitionsByName
	(
		@Name varchar(50),
		@SiteId [bigint]
	)
AS

SELECT
	Count(ActionItemDefinition.[Id]) as COUNT
FROM         
	ActionItemDefinition,
	ActionItemDefinitionFunctionalLocation,
	FunctionalLocation
WHERE 
	ActionItemDefinition.[Id] = ActionItemDefinitionFunctionalLocation.ActionItemDefinitionId
	AND
	ActionItemDefinitionFunctionalLocation.FunctionalLocationId = FunctionalLocation.[Id]
	AND
	ActionItemDefinition.Deleted  = 0
	AND
	FunctionalLocation.SiteId = @SiteId
	AND
    LOWER(ActionItemDefinition.[Name]) = LOWER(@Name)
	AND
	ActionItemDefinition.SourceId = 1 -- From SAP
GO

GRANT EXEC ON CountSAPSourcedActionItemDefinitionsByName TO PUBLIC
GO