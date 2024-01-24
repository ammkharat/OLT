IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySapAutoImportConfigurationBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QuerySapAutoImportConfigurationBySiteId
	END
GO
					 
CREATE Procedure dbo.QuerySapAutoImportConfigurationBySiteId(@SiteId bigint)
AS
select * from SapAutoImportConfiguration where SiteId = @SiteId	
GO

GRANT EXEC ON [QuerySapAutoImportConfigurationBySiteId] TO PUBLIC
GO