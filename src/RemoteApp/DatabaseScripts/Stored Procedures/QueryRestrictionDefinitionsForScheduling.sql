IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionDefinitionsForScheduling')
	BEGIN
		DROP PROCEDURE [dbo].QueryRestrictionDefinitionsForScheduling
	END
GO

CREATE Procedure [dbo].QueryRestrictionDefinitionsForScheduling
AS 

SELECT *
FROM RestrictionDefinition
WHERE Deleted  = 0
GO

GRANT EXEC ON QueryRestrictionDefinitionsForScheduling TO PUBLIC
GO