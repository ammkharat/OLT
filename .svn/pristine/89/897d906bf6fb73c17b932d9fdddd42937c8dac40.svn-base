IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverConfigurationDTOBySite')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverConfigurationDTOBySite
	END
GO

CREATE Procedure dbo.QueryShiftHandoverConfigurationDTOBySite
	(
	@SiteId bigint
	)
AS

select distinct c.* from ShiftHandoverConfiguration c
inner join ShiftHandoverConfigurationWorkAssignment shcwa on shcwa.ShiftHandoverConfigurationId = c.Id
inner join WorkAssignment wa on shcwa.WorkAssignmentId = wa.Id
where wa.SiteId = @SiteId
and c.Deleted = 0
GO

GRANT EXEC ON [QueryShiftHandoverConfigurationDTOBySite] TO PUBLIC
GO