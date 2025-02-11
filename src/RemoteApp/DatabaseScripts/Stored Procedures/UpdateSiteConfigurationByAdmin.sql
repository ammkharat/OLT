IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSiteConfigurationByAdmin')
	BEGIN
		DROP Procedure [dbo].UpdateSiteConfigurationByAdmin
	END
GO


Create Procedure [dbo].[UpdateSiteConfigurationByAdmin]
	(
	@SiteId bigint,	
	@ActionItemFlocLevel [int],
	@ShiftLogFlocLevel [int],
	@ShiftHandoverFlocLevel [int]
	)
AS
 
 UPDATE
   SiteConfiguration
 SET
 	ActionItemFlocLevel = @ActionItemFlocLevel,
	ShiftLogFlocLevel = @ShiftLogFlocLevel ,
	ShiftHandoverFlocLevel = @ShiftHandoverFlocLevel
WHERE  
	SiteId = @SiteId

GRANT EXEC ON UpdateSiteConfigurationByAdmin TO PUBLIC
