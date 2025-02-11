IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoadAccessOnPermitByNameAndWorkCentreAndSiteId')
	BEGIN
		DROP  Procedure  QueryRoadAccessOnPermitByNameAndWorkCentreAndSiteId
	END

GO
  
Create Procedure [dbo].[QueryRoadAccessOnPermitByNameAndWorkCentreAndSiteId]  
 (  
  @Name varchar(50),  
  @WorkCenter varchar(10) = NULL,  
  @SiteId bigint    
 )  
  
AS  
select * from RoadAccessOnPermit  
where [Name] = @Name  
and SiteId = @SiteId  
and ((@WorkCenter is null and WorkCenter is null) or (@WorkCenter is not null and @WorkCenter = WorkCenter))  
and Deleted = 0  



GRANT EXEC ON QueryRoadAccessOnPermitByNameAndWorkCentreAndSiteId TO PUBLIC        
        
        GO
 
 