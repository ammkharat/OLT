
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDoesPermitRequestMudsAssociationExist')
	BEGIN
		DROP Procedure [dbo].QueryDoesPermitRequestMudsAssociationExist
	END
GO

CREATE Procedure [dbo].[QueryDoesPermitRequestMudsAssociationExist]  
 (  
  @WorkPermitStartDate datetime,  
  @PermitRequestIds VARCHAR(MAX)  
 )  
AS  
  
DECLARE @StartDate VARCHAR(MAX)  
SET @StartDate = CONVERT(VARCHAR(10),@WorkPermitStartDate,101) -- 101 has format: mm/dd/yyyy  
  
SELECT   
 COUNT(wpm.Id) as COUNT  
FROM   
 [dbo].[WorkPermitMuds] wpm  
WHERE   
 CONVERT(VARCHAR(10),wpm.StartDateTime,101) = @StartDate  
 AND  
 EXISTS  
 (  
  SELECT Id FROM IDSplitter(@PermitRequestIds) WHERE Id = wpm.PermitRequestId  
 )
GO


GRANT EXEC ON QueryDoesPermitRequestMudsAssociationExist TO PUBLIC
GO

