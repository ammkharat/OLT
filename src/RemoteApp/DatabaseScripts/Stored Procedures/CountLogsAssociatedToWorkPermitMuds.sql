
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogsAssociatedToWorkPermitMuds')
	BEGIN
		DROP Procedure [dbo].CountLogsAssociatedToWorkPermitMuds
	END
GO

CREATE Procedure [dbo].[CountLogsAssociatedToWorkPermitMuds]  
 (  
  @WorkPermitMudsId [bigint]  
 )  
AS  
  
SELECT  
 Count(assoc.LogId) as COUNT  
FROM  
 [LogWorkPermitMudsAssociation] assoc  
 inner join [Log] l on l.Id = assoc.LogId  
WHERE  
 assoc.WorkPermitMudsId = @WorkPermitMudsId and  
 l.Deleted = 0  
 
 GRANT EXEC ON CountLogsAssociatedToWorkPermitMuds TO PUBLIC
GO
