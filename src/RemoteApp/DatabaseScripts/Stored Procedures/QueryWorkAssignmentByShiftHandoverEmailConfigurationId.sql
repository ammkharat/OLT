IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentByShiftHandoverEmailConfigurationId')
	BEGIN
		DROP PROCEDURE dbo.QueryWorkAssignmentByShiftHandoverEmailConfigurationId
	END
GO

CREATE Procedure dbo.QueryWorkAssignmentByShiftHandoverEmailConfigurationId(@ConfigurationId bigint)
AS

select * from WorkAssignment wa
inner join ShiftHandoverEmailConfigurationWorkAssignment shecwa on wa.Id = shecwa.WorkAssignmentId
where shecwa.ShiftHandoverEmailConfigurationId = @ConfigurationId
order by wa.[Name]
GO  

GRANT EXEC ON QueryWorkAssignmentByShiftHandoverEmailConfigurationId TO PUBLIC
GO