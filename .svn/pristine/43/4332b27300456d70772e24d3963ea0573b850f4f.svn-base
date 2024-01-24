  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveShiftHandoverConfiguration')
	BEGIN
		DROP  Procedure  RemoveShiftHandoverConfiguration
	END

GO

CREATE Procedure dbo.RemoveShiftHandoverConfiguration
	(	
	@Id bigint
	)
AS
update ShiftHandoverConfiguration 
set Deleted = 1
WHERE Id = @Id

RETURN

GO    