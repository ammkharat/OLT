IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllSiteCommunication')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllSiteCommunication
	END
GO

CREATE Procedure dbo.QueryAllSiteCommunication
AS
SELECT * 
FROM SiteCommunication
WHERE 
  Deleted = 0
ORDER BY StartDateTime asc
GO

GRANT EXEC ON QueryAllSiteCommunication TO PUBLIC
GO