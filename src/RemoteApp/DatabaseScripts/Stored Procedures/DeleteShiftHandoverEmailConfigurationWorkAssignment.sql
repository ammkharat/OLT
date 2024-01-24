  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteShiftHandoverEmailConfigurationWorkAssignments')
	BEGIN
		DROP  Procedure  DeleteShiftHandoverEmailConfigurationWorkAssignments
	END

GO

CREATE Procedure dbo.DeleteShiftHandoverEmailConfigurationWorkAssignments(@ConfigurationId bigint)
AS

delete from ShiftHandoverEmailConfigurationWorkAssignment where ShiftHandoverEmailConfigurationId = @ConfigurationId;
  
RETURN

GO    