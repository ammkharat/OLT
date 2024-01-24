IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverEmailConfigurationWorkAssignment')
	BEGIN
		DROP  Procedure  InsertShiftHandoverEmailConfigurationWorkAssignment
	END

GO

CREATE Procedure dbo.InsertShiftHandoverEmailConfigurationWorkAssignment
(
    @ShiftHandoverEmailConfigurationId bigint,
    @WorkAssignmentId bigint
)
AS

INSERT INTO ShiftHandoverEmailConfigurationWorkAssignment
(
    ShiftHandoverEmailConfigurationId,
    WorkAssignmentId
)
VALUES
(
    @ShiftHandoverEmailConfigurationId,
    @WorkAssignmentId
)

GO
  