IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTagById')
	BEGIN
		DROP PROCEDURE [dbo].QueryTagById
	END
GO

CREATE Procedure [dbo].QueryTagById
	(
		@id int
	)
AS

SELECT * 
FROM 
	Tag 
WHERE 
ID=@id
GO

GRANT EXEC ON QueryTagById TO PUBLIC
GO