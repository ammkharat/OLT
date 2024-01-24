IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverConfigurationWorkAssignment')
	BEGIN
		DROP  Procedure  InsertShiftHandoverConfigurationWorkAssignment
	END

GO

CREATE Procedure [dbo].[InsertShiftHandoverConfigurationWorkAssignment]
(
    @ShiftHandoverConfigurationId bigint,
    @WorkAssignmentId bigint
)
AS

INSERT INTO [ShiftHandoverConfigurationWorkAssignment]
(
    [ShiftHandoverConfigurationId],
    [WorkAssignmentId]
)
VALUES
(
    @ShiftHandoverConfigurationId,
    @WorkAssignmentId
)

GO
  