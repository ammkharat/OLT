if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAllFormMudsTemporaryInstallationThatAreApprovedAndOutOfServiceForMoreThan3Days]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAllFormMudsTemporaryInstallationThatAreApprovedAndOutOfServiceForMoreThan3Days]
GO

CREATE Procedure [dbo].[QueryAllFormMudsTemporaryInstallationThatAreApprovedAndOutOfServiceForMoreThan3Days]  
(  
 @Now datetime  
)  
AS  
select form.*  
from FormMudsTemporaryInstallation form  
where (form.FormStatusId = 2 OR form.FormStatusId = 5) -- approved or expired  
and datediff(minute, form.ValidFromDateTime, @Now) > (1440 * 3)                 --- 1440 minutes per day, 3 days  



GRANT EXEC ON QueryAllFormMudsTemporaryInstallationThatAreApprovedAndOutOfServiceForMoreThan3Days TO PUBLIC
GO



