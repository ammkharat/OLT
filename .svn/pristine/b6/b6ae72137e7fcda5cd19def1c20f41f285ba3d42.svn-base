IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSapAutoImportConfiguration')
	BEGIN
		DROP  Procedure  UpdateSapAutoImportConfiguration
	END

GO

CREATE Procedure [dbo].UpdateSapAutoImportConfiguration
	(
	    @SiteId bigint,
		@ScheduleId bigint = null		
	)

AS
	update SapAutoImportConfiguration set ScheduleId = @ScheduleId where SiteId = @SiteId
GO


