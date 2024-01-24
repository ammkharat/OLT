IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePriorityPageSectionConfigurationWorkAssignmentByConfigurationId')
	BEGIN
		DROP  Procedure  DeletePriorityPageSectionConfigurationWorkAssignmentByConfigurationId
	END
GO

CREATE Procedure [dbo].[DeletePriorityPageSectionConfigurationWorkAssignmentByConfigurationId]
(
    @ConfigurationId bigint	
)
AS

delete from PriorityPageSectionConfigurationWorkAssignment where PriorityPageSectionConfigurationId = @ConfigurationId;

GO
 