IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySiteCommunicationDTOBySiteAndDateTime')
	BEGIN
		DROP PROCEDURE [dbo].QuerySiteCommunicationDTOBySiteAndDateTime
	END
GO

CREATE Procedure dbo.QuerySiteCommunicationDTOBySiteAndDateTime
	(
	@SiteId bigint,
	@DateTime datetime
	)
AS

SELECT Id, Message
FROM SiteCommunication
WHERE 
  SiteId = @SiteId AND
  StartDateTime <= @DateTime AND
  @DateTime <= EndDateTime AND
  Deleted = 0
ORDER BY StartDateTime asc
GO

GRANT EXEC ON QuerySiteCommunicationDTOBySiteAndDateTime TO PUBLIC
GO