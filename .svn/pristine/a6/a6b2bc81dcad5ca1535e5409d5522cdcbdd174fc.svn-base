 IF (OBJECT_ID('QueryAllFormOP14ThatAreApprovedAndOutOfServiceForMoreThan10Days') IS NOT NULL)
  DROP PROCEDURE QueryAllFormOP14ThatAreApprovedAndOutOfServiceForMoreThan10Days
GO

CREATE Procedure [dbo].[QueryAllFormOP14ThatAreApprovedAndOutOfServiceForMoreThan10Days]  
(  
 @Now datetime  
)  
AS  
select form.*  
from FormOP14 form  
where (form.FormStatusId = 2 OR form.FormStatusId = 5) -- approved or expired  
and datediff(minute, form.ValidFromDateTime, @Now) > (1440 * 10)                 --- 1440 minutes per day, 10 days  


GRANT EXEC ON QueryAllFormOP14ThatAreApprovedAndOutOfServiceForMoreThan10Days TO PUBLIC