IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmExcursionByOpmExcursionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmExcursionByOpmExcursionId
	END
GO

CREATE Procedure [dbo].QueryOpmExcursionByOpmExcursionId
(
	@id bigint
)
AS

SELECT 
	ex.*

FROM OpmExcursion ex
WHERE ex.OpmExcursionId=@id
GO

GRANT EXEC ON QueryOpmExcursionByOpmExcursionId TO PUBLIC
GO