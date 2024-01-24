IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountTargetDefinitionsByName')
	BEGIN
		DROP PROCEDURE [dbo].CountTargetDefinitionsByName
	END
GO

CREATE Procedure [dbo].CountTargetDefinitionsByName
	(
		@Name varchar (50),
		@SiteId bigint
	)
AS


SELECT
	Count(TD.Id) as COUNT
FROM
	TargetDefinition AS TD, FunctionalLocation AS FL
WHERE
	TD.Deleted  = 0
	AND
	LOWER(TD.[Name]) = LOWER(@Name)
	AND
	TD.FunctionalLocationId = FL.Id
	AND
	FL.SiteId = @SiteId
GO

GRANT EXEC ON CountTargetDefinitionsByName TO PUBLIC
GO