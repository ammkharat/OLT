IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogsAssociatedToActionItemDefinition')
	BEGIN
		DROP Procedure [dbo].CountLogsAssociatedToActionItemDefinition
	END
GO

CREATE Procedure [dbo].CountLogsAssociatedToActionItemDefinition
	(
		@ActionItemDefinitionId [bigint]
	)
AS

SELECT
	Count(laida.LogId) as COUNT
FROM
	[LogActionItemDefinitionAssociation] laida
	join [Log] l on l.Id = laida.LogId
WHERE
	laida.ActionItemDefinitionId = @ActionItemDefinitionId and
	l.Deleted = 0
	
GO

GRANT EXEC ON CountLogsAssociatedToActionItemDefinition TO PUBLIC
GO