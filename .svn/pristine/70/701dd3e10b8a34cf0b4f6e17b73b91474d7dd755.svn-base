IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetSearchPermitNumber')
	BEGIN
		DROP PROCEDURE [dbo].GetSearchPermitNumber
	END
	
GO
CREATE Procedure [dbo].[GetSearchPermitNumber]  
(  
   
 @SiteId Int=null  
   
)  
AS  
  
if(@SiteId=8)  
Begin  
  
select PermitNumber from WorkPermitEdmonton where WorkPermitStatusId=3 and IssuedDateTime>DATEADD(month, -6, GETDATE())   
  
END  
ELSE if(@SiteId=1)  
Begin  
  
select PermitNumber from workpermit where WorkPermitStatusId=5 and PermitNumber like '%SR1%'  and StartDateTime>DATEADD(month, -3, GETDATE())   
  
END  
ELSE if(@SiteId=2)  
Begin  
  
select PermitNumber from workpermit where WorkPermitStatusId=5 and PermitNumber like '%DN1%'  and StartDateTime>DATEADD(month, -3, GETDATE())   
  
END  
else if(@SiteId=16)  
Begin  
  
select PermitNumber from WorkPermitMuds where WorkPermitStatusId=3 and IssuedDateTime>DATEADD(month, -6, GETDATE())   
  
END  

if(@SiteId=9)  
Begin  
  
select PermitNumber from WorkPermitMontreal where WorkPermitStatusId=3 and IssuedDateTime>DATEADD(month, -6, GETDATE())   
 
END  

ELSE  
BEGIN  
 select 0 AS PermitNumber  
END  
  
GRANT EXEC ON GetSearchPermitNumber TO PUBLIC     


  
  
  
  
  
  
  






