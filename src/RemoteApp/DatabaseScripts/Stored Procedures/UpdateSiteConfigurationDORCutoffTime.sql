  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSiteConfigurationDORCutoffTime')
	BEGIN
		DROP  Procedure  UpdateSiteConfigurationDORCutoffTime
	END

GO

CREATE Procedure [dbo].[UpdateSiteConfigurationDORCutoffTime]
	(
		@SiteId bigint,
		@DORCutoffTime datetime
	)
AS
 
 UPDATE    
	SiteConfiguration
 SET
	 DORCutoffTime = @DORCutoffTime                      
WHERE  
	SiteId = @SiteId
GO

GRANT EXEC ON UpdateSiteConfigurationDORCutoffTime TO PUBLIC

GO