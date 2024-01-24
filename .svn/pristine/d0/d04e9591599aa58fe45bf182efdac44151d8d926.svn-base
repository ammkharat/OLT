IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardByConfigurationAndShift')
	BEGIN
		DROP PROCEDURE [dbo].QueryCokerCardByConfigurationAndShift
	END
GO

CREATE Procedure [dbo].QueryCokerCardByConfigurationAndShift
(
	@CokerCardConfigurationId bigint,
	@ShiftId bigint,
	@ShiftStartDate datetime
)
AS

SELECT 
	cc.*,
	ccf.Name as CokerCardConfigurationName
FROM CokerCard cc,
CokerCardConfiguration ccf
WHERE cc.CokerCardConfigurationId = ccf.Id
and cc.CokerCardConfigurationId = @CokerCardConfigurationId
and cc.ShiftId = @ShiftId
and cc.ShiftStartDate = @ShiftStartDate
and cc.Deleted = 0
GO

GRANT EXEC ON QueryCokerCardByConfigurationAndShift TO PUBLIC
GO