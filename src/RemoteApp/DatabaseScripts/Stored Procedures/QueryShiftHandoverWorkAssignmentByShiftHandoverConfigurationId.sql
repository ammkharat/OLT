IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverWorkAssignmentByShiftHandoverConfigurationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverWorkAssignmentByShiftHandoverConfigurationId
	END
GO

CREATE Procedure [dbo].QueryShiftHandoverWorkAssignmentByShiftHandoverConfigurationId
	(
		@ShiftHandoverConfigurationId bigint
	)
AS

select 
	shcwa.* 
from 
	ShiftHandoverConfigurationWorkAssignment shcwa
	inner join WorkAssignment wa on shcwa.WorkAssignmentId = wa.Id
where 
	ShiftHandoverConfigurationId = @ShiftHandoverConfigurationId
	and wa.Deleted = 0
GO

GRANT EXEC ON QueryShiftHandoverWorkAssignmentByShiftHandoverConfigurationId TO PUBLIC
GO