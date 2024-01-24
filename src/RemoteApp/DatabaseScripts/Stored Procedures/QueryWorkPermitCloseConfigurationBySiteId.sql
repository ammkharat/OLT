IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitCloseConfigurationBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitCloseConfigurationBySiteId
	END
GO

CREATE Procedure dbo.QueryWorkPermitCloseConfigurationBySiteId
	(
	@SiteId bigint
	)
AS

SELECT * FROM WorkPermitCloseConfiguration WHERE SiteId=@SiteId 
GO

GRANT EXEC ON QueryWorkPermitCloseConfigurationBySiteId TO PUBLIC
GO