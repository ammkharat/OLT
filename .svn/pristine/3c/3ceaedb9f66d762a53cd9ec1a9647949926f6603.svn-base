IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllEdmontonPersons')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllEdmontonPersons
	END
GO

CREATE Procedure [dbo].QueryAllEdmontonPersons
AS

SELECT 
	* 
FROM 
	EdmontonPerson
where 
	Deleted = 0
ORDER BY
	LastName, FirstName, BadgeId
GO

GRANT EXEC ON QueryAllEdmontonPersons TO PUBLIC
GO