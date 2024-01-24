if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAllFormLubesCsdThatAreApprovedAndOutOfServiceForMoreThan10Days]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAllFormLubesCsdThatAreApprovedAndOutOfServiceForMoreThan10Days]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAllFormLubesCsdThatAreApprovedAndOutOfServiceForMoreThan7Days]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAllFormLubesCsdThatAreApprovedAndOutOfServiceForMoreThan7Days]
GO


CREATE Procedure [dbo].[QueryAllFormLubesCsdThatAreApprovedAndOutOfServiceForMoreThan7Days]
(
	@Now datetime
)
AS
select form.*
from FormLubesCsd form
where (form.FormStatusId = 2 OR form.FormStatusId = 5) -- approved or expired
and datediff(minute, form.ValidFromDateTime, @Now) > (1440 * 7)                 --- 1440 minutes per day, 7 days
