IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverEmailConfigurationBySiteId')
	BEGIN
		DROP PROCEDURE dbo.QueryShiftHandoverEmailConfigurationBySiteId
	END
GO

CREATE Procedure dbo.QueryShiftHandoverEmailConfigurationBySiteId(@SiteId bigint)
AS

select * From ShiftHandoverEmailConfiguration where SiteId = @SiteId

GO

GRANT EXEC ON QueryShiftHandoverEmailConfigurationBySiteId TO PUBLIC
GO