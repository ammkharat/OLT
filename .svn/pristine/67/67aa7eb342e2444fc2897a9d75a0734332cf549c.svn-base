  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSiteConfigurationLabAlertRetryAttemptLimit')
	BEGIN
		DROP  Procedure  UpdateSiteConfigurationLabAlertRetryAttemptLimit
	END

GO

CREATE Procedure [dbo].[UpdateSiteConfigurationLabAlertRetryAttemptLimit]
	(
		@SiteId bigint,
		@LabAlertRetryAttemptLimit int
	)
AS
 
UPDATE    
	SiteConfiguration
SET
	 LabAlertRetryAttemptLimit = @LabAlertRetryAttemptLimit                      
WHERE  
	SiteId = @SiteId
GO

GRANT EXEC ON UpdateSiteConfigurationLabAlertRetryAttemptLimit TO PUBLIC

GO