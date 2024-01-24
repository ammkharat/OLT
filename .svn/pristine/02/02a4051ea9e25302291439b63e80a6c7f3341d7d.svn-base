IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPriorityPageSectionConfigurationWorkAssignment')
	BEGIN
		DROP  Procedure  InsertPriorityPageSectionConfigurationWorkAssignment
	END
GO

CREATE Procedure [dbo].InsertPriorityPageSectionConfigurationWorkAssignment
(
	@ConfigurationId bigint,
	@WorkAssignmentId bigint
)
AS

INSERT INTO PriorityPageSectionConfigurationWorkAssignment (PriorityPageSectionConfigurationId, WorkAssignmentId)
VALUES (@ConfigurationId, @WorkAssignmentId)

GO

GRANT EXEC ON InsertPriorityPageSectionConfigurationWorkAssignment TO PUBLIC
GO