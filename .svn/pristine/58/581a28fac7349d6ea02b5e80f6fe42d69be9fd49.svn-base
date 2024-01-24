  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSiteConfigurationRestrictionReportingLimits')
	BEGIN
		DROP  Procedure  UpdateSiteConfigurationRestrictionReportingLimits
	END

GO

CREATE Procedure [dbo].[UpdateSiteConfigurationRestrictionReportingLimits]
	(
		@SiteId bigint,
		@DaysToEditDeviationAlerts int
	)
AS
 
 UPDATE    
	SiteConfiguration
 SET
	 DaysToEditDeviationAlerts = @DaysToEditDeviationAlerts                      
WHERE  
	SiteId = @SiteId
GO

GRANT EXEC ON UpdateSiteConfigurationRestrictionReportingLimits TO PUBLIC

GO