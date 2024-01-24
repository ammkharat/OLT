  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteShiftHandoverConfigurationWorkAssignmentByShiftHandoverConfigurationId')
	BEGIN
		DROP  Procedure  DeleteShiftHandoverConfigurationWorkAssignmentByShiftHandoverConfigurationId
	END

GO

CREATE Procedure dbo.DeleteShiftHandoverConfigurationWorkAssignmentByShiftHandoverConfigurationId
	(	
	@ShiftHandoverConfigurationId bigint
	)
AS
DELETE FROM ShiftHandoverConfigurationWorkAssignment 
WHERE ShiftHandoverConfigurationId = @ShiftHandoverConfigurationId

RETURN

GO    

