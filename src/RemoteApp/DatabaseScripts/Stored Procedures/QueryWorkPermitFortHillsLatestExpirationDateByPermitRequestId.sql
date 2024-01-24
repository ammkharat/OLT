  
  
  
  
  IF OBJECT_ID('QueryWorkPermitFortHillsLatestExpirationDateByPermitRequestId', 'P') IS NOT NULL
DROP PROC QueryWorkPermitFortHillsLatestExpirationDateByPermitRequestId
GO  
CREATE Procedure [dbo].[QueryWorkPermitFortHillsLatestExpirationDateByPermitRequestId]  
(  
 @PermitRequestId bigint  
)  
AS  
select MAX(ExpiredDateTime) as LatestExpiryDateTime from WorkPermitFortHills where PermitRequestId = @PermitRequestId  

 GRANT EXEC ON QueryWorkPermitFortHillsLatestExpirationDateByPermitRequestId TO PUBLIC  