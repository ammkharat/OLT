IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardConfigurationWorkAssignmentByConfigurationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCokerCardConfigurationWorkAssignmentByConfigurationId
	END
GO

CREATE Procedure [dbo].QueryCokerCardConfigurationWorkAssignmentByConfigurationId
(
	@CokerCardConfigurationId bigint
)
AS

SELECT ca.*
FROM CokerCardConfigurationWorkAssignment ca,
WorkAssignment a
WHERE ca.WorkAssignmentId = a.Id
and CokerCardConfigurationId = @CokerCardConfigurationId
and a.Deleted = 0
GO

GRANT EXEC ON QueryCokerCardConfigurationWorkAssignmentByConfigurationId TO PUBLIC
GO