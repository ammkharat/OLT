if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan10Days]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan10Days]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan3Days]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan3Days]
GO
CREATE Procedure [dbo].[QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan3Days]
(
	@Now datetime
)
AS
select form.*
from FormMontrealCsd form
where (form.FormStatusId = 2 OR form.FormStatusId = 5) -- approved or expired
and datediff(minute, form.ValidFromDateTime, @Now) > (1440 * 3)                 --- 1440 minutes per day, 3 days
