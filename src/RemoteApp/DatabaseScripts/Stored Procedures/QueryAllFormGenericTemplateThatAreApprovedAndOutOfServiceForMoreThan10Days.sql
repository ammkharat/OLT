if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAllFormGenericTemplateThatAreApprovedAndOutOfServiceForMoreThan10Days]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAllFormGenericTemplateThatAreApprovedAndOutOfServiceForMoreThan10Days]
GO


CREATE Procedure [dbo].[QueryAllFormGenericTemplateThatAreApprovedAndOutOfServiceForMoreThan10Days]
(
	@Now datetime
)
AS
select form.*
from FormGenericTemplate form
where (form.FormStatusId = 2 OR form.FormStatusId = 5) -- approved or expired
and datediff(minute, form.ValidFromDateTime, @Now) > (1440 * 10)                 --- 1440 minutes per day, 10 days



GO

GRANT EXEC ON QueryAllFormGenericTemplateThatAreApprovedAndOutOfServiceForMoreThan10Days TO PUBLIC
GO
