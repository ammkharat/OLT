  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteShiftHandoverEmailConfiguration')
	BEGIN
		DROP  Procedure  DeleteShiftHandoverEmailConfiguration
	END

GO

CREATE Procedure dbo.DeleteShiftHandoverEmailConfiguration(@Id bigint)
AS

delete from ShiftHandoverEmailConfigurationWorkAssignment where ShiftHandoverEmailConfigurationId = @Id;

DELETE FROM ShiftHandoverEmailConfiguration where Id = @Id;
  
RETURN

GO    