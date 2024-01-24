IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmExcursionResponseById')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmExcursionResponseById
	END
GO

CREATE Procedure [dbo].QueryOpmExcursionResponseById
(
	@id bigint
)
AS

SELECT 
	res.*

FROM OpmExcursionResponse res
WHERE res.ID=@id
GO

GRANT EXEC ON QueryOpmExcursionResponseById TO PUBLIC
GO