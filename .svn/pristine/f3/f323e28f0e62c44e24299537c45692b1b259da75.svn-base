IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverConfigurationByWorkAssignment')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverConfigurationByWorkAssignment
	END
GO

CREATE Procedure dbo.QueryShiftHandoverConfigurationByWorkAssignment
	(
	@WorkAssignmentId bigint
	)
AS

select distinct shc.* from ShiftHandoverConfigurationWorkAssignment shcwa
inner join ShiftHandoverConfiguration shc on shcwa.ShiftHandoverConfigurationId = shc.Id
where 
shc.Deleted = 0
and shcwa.WorkAssignmentId = @WorkAssignmentId
GO

GRANT EXEC ON [QueryShiftHandoverConfigurationByWorkAssignment] TO PUBLIC
GO