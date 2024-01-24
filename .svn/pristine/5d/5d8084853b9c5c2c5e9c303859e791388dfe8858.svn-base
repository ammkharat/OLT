IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogById')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogById
	END
GO

CREATE Procedure [dbo].QueryLogById
	(
		@id int
	)
AS

SELECT
    *
FROM 
	[Log]
WHERE 
	Id=@id 
GO

GRANT EXEC ON QueryLogById TO PUBLIC
GO