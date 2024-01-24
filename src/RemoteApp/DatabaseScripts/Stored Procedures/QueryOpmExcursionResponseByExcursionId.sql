IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmExcursionResponseByExcursionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmExcursionResponseByExcursionId
	END
GO

CREATE Procedure [dbo].QueryOpmExcursionResponseByExcursionId
(
	@id bigint
)
AS

SELECT 
	res.*

FROM OpmExcursionResponse res
WHERE res.OltExcursionId=@id
GO

GRANT EXEC ON QueryOpmExcursionResponseByExcursionId TO PUBLIC
GO