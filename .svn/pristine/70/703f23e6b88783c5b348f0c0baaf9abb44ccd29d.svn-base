
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan5Days]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan5Days]
GO
CREATE Procedure [dbo].[QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan5Days]
(
	@Now datetime
)
AS
select form.*
from FormMontrealCsd form
where (form.FormStatusId = 2 OR form.FormStatusId = 5) -- approved or expired
and datediff(minute, form.ValidFromDateTime, @Now) > (1440 * 5)                 --- 1440 minutes per day, 5 days
