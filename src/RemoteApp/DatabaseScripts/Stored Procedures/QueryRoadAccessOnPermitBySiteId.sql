IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoadAccessOnPermitBySiteId')
	BEGIN
		DROP  Procedure  QueryRoadAccessOnPermitBySiteId
	END

GO
  
Create Procedure [dbo].[QueryRoadAccessOnPermitBySiteId]        
        
 (        
  @SiteId int        
 )        
        
AS        
        
SELECT     *        
FROM         [RoadAccessOnPermit] WHERE SiteId=@SiteId   
And Deleted = 0



GRANT EXEC ON QueryRoadAccessOnPermitBySiteId TO PUBLIC        
        
        GO