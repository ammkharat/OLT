IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertCokerCardConfigurationWorkAssignment')
	BEGIN
		DROP  Procedure  InsertCokerCardConfigurationWorkAssignment
	END
GO

CREATE Procedure [dbo].InsertCokerCardConfigurationWorkAssignment
(
	@CokerCardConfigurationId bigint,
	@WorkAssignmentId bigint
)
AS

INSERT INTO CokerCardConfigurationWorkAssignment 
(
	CokerCardConfigurationId,
	WorkAssignmentId
)
VALUES
(
	@CokerCardConfigurationId,
	@WorkAssignmentId
)

GO

GRANT EXEC ON InsertCokerCardConfigurationWorkAssignment TO PUBLIC
GO