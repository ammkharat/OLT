if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAllFormLubesAlarmDisableThatAreApprovedAndOutOfServiceForMoreThan7Days]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAllFormLubesAlarmDisableThatAreApprovedAndOutOfServiceForMoreThan7Days]
GO

CREATE Procedure [dbo].[QueryAllFormLubesAlarmDisableThatAreApprovedAndOutOfServiceForMoreThan7Days]
(
	@Now datetime
)
AS
select form.*
from FormLubesAlarmDisable form
where (form.FormStatusId = 2 OR form.FormStatusId = 5) -- approved or expired
and datediff(minute, form.ValidFromDateTime, @Now) > (1440 * 7)                 --- 1440 minutes per day, 7 days
