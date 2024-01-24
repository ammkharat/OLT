IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmExcursionByMostRecentUpdateDateTime')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmExcursionByMostRecentUpdateDateTime
	END
GO

CREATE Procedure [dbo].QueryOpmExcursionByMostRecentUpdateDateTime
AS

SELECT TOP 1 
	ex.*

FROM OpmExcursion ex
ORDER BY LastUpdatedDateTime desc
GO

GRANT EXEC ON QueryOpmExcursionByMostRecentUpdateDateTime TO PUBLIC
GO