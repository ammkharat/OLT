  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSiteConfigurationHideDORCommentEntry')
	BEGIN
		DROP  Procedure  UpdateSiteConfigurationHideDORCommentEntry
	END

GO

CREATE Procedure [dbo].[UpdateSiteConfigurationHideDORCommentEntry]
	(
		@SiteId bigint,
		@HideDORCommentEntry bit
	)
AS
 
 UPDATE    
	SiteConfiguration
 SET
	 HideDORCommentEntry = @HideDORCommentEntry                      
WHERE  
	SiteId = @SiteId
GO

GRANT EXEC ON UpdateSiteConfigurationHideDORCommentEntry TO PUBLIC

GO