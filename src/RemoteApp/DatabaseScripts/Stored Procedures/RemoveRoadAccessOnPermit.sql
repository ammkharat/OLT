IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveRoadAccessOnPermit')
	BEGIN
		DROP  Procedure  RemoveRoadAccessOnPermit
	END

GO
  
Create Procedure [dbo].[RemoveRoadAccessOnPermit]  
 (  
  @Id BIGINT  
 )  
AS  
  
UPDATE [dbo].[RoadAccessOnPermit]  
SET Deleted = 1  
WHERE Id = @Id  



GRANT EXEC ON RemoveRoadAccessOnPermit TO PUBLIC        
        
        GO

