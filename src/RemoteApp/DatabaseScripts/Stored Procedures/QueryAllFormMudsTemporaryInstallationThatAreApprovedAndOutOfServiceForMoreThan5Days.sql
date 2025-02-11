if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAllFormMudsTemporaryInstallationThatAreApprovedAndOutOfServiceForMoreThan5Days]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAllFormMudsTemporaryInstallationThatAreApprovedAndOutOfServiceForMoreThan5Days]
GO


CREATE Procedure [dbo].[QueryAllFormMudsTemporaryInstallationThatAreApprovedAndOutOfServiceForMoreThan5Days]  
(  
 @Now datetime  
)  
AS  
select form.*  
from FormMudsTemporaryInstallation form  
where (form.FormStatusId = 2 OR form.FormStatusId = 5) -- approved or expired  
and datediff(minute, form.ValidFromDateTime, @Now) > (1440 * 5)                 --- 1440 minutes per day, 5 days  


GRANT EXEC ON QueryAllFormMudsTemporaryInstallationThatAreApprovedAndOutOfServiceForMoreThan5Days TO PUBLIC
GO
