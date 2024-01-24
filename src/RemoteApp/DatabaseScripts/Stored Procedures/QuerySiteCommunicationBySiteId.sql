IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySiteCommunicationBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QuerySiteCommunicationBySiteId
	END
GO

CREATE Procedure dbo.QuerySiteCommunicationBySiteId
	(
	@SiteId bigint
	)
AS
SELECT * 
FROM SiteCommunication
WHERE 
  SiteId = @SiteId AND
  Deleted = 0
ORDER BY StartDateTime asc
GO

GRANT EXEC ON QuerySiteCommunicationBySiteId TO PUBLIC
GO