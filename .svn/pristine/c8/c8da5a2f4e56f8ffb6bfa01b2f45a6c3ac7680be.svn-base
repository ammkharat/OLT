IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteCokerCardConfigurationWorkAssignmentByConfigurationId')
	BEGIN
		DROP  Procedure  DeleteCokerCardConfigurationWorkAssignmentByConfigurationId
	END
GO

CREATE Procedure [dbo].DeleteCokerCardConfigurationWorkAssignmentByConfigurationId
(
	@CokerCardConfigurationId bigint
)
AS

DELETE
FROM CokerCardConfigurationWorkAssignment 
WHERE CokerCardConfigurationId = @CokerCardConfigurationId

GO

GRANT EXEC ON DeleteCokerCardConfigurationWorkAssignmentByConfigurationId TO PUBLIC
GO