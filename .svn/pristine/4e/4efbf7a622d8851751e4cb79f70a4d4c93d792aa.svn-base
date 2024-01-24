IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmExcursionById')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmExcursionById
	END
GO

CREATE Procedure [dbo].QueryOpmExcursionById
(
	@id bigint
)
AS

SELECT 
	ex.*

FROM OpmExcursion ex
WHERE ex.ID=@id
GO

GRANT EXEC ON QueryOpmExcursionById TO PUBLIC
GO