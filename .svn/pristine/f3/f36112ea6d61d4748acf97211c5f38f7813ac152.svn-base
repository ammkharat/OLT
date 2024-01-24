IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentByPriorityPageSectionConfigurationId')
	BEGIN
		DROP PROCEDURE dbo.QueryWorkAssignmentByPriorityPageSectionConfigurationId
	END
GO

CREATE Procedure dbo.QueryWorkAssignmentByPriorityPageSectionConfigurationId(@PriorityPageSectionConfigurationId bigint)
AS

select * from WorkAssignment wa
inner join PriorityPageSectionConfigurationWorkAssignment ppwa on wa.Id = ppwa.WorkAssignmentId
where ppwa.PriorityPageSectionConfigurationId = @PriorityPageSectionConfigurationId
order by wa.[Name]
GO  

GRANT EXEC ON QueryWorkAssignmentByPriorityPageSectionConfigurationId TO PUBLIC
GO