IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverConfigurationById')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverConfigurationById
	END
GO

CREATE Procedure [dbo].QueryShiftHandoverConfigurationById
	(
	@Id bigint
	)
AS

SELECT * 
FROM ShiftHandoverConfiguration 
WHERE Id = @Id
and Deleted = 0
GO

GRANT EXEC ON [QueryShiftHandoverConfigurationById] TO PUBLIC
GO