  

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllGasTestElementByWorkPermitMudsId')
    BEGIN
        DROP PROCEDURE [dbo].QueryAllGasTestElementByWorkPermitMudsId
    END
GO
CREATE Procedure [dbo].[QueryAllGasTestElementByWorkPermitMudsId]  
    (  
    @WorkPermitId bigint,  
 @siteid bigint  
    )  
AS  
    SELECT  
        WorkPermitGasTestElementInfoMUDS.*  
    FROM  
        WorkPermitGasTestElementInfoMUDS, GasTestElementInfo  
    WHERE  
        WorkPermitGasTestElementInfoMUDS.GasTestElementInfoId = GasTestElementInfo.Id AND  
        GasTestElementInfo.Deleted = 0 AND  
  GasTestElementInfo.SiteId = @siteid AND  
        WorkPermitGasTestElementInfoMUDS.WorkPermitId = @WorkPermitId  
   
   GRANT EXEC ON QueryAllGasTestElementByWorkPermitMudsId TO PUBLIC   