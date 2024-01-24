IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllDeletedEdmontonPersons')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllDeletedEdmontonPersons
	END
GO

CREATE Procedure [dbo].QueryAllDeletedEdmontonPersons
AS

SELECT 
	* 
FROM 
	EdmontonPerson
where 
	Deleted = 1
GO

GRANT EXEC ON QueryAllDeletedEdmontonPersons TO PUBLIC
GO