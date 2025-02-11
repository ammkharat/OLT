IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateRoadAccessOnPermit')
	BEGIN
		DROP  Procedure  UpdateRoadAccessOnPermit
	END

GO
    
Create Procedure [dbo].[UpdateRoadAccessOnPermit]  
 (  
  @Id BIGINT,  
  @Name VARCHAR(50),  
  @WorkCenter VARCHAR(10) = null  
 )  
  
AS  
UPDATE [dbo].[RoadAccessOnPermit]   
 SET   
     [Name] = @Name,   
     WorkCenter = @WorkCenter   
 WHERE Id = @Id  
 
 
 
GRANT EXEC ON UpdateRoadAccessOnPermit TO PUBLIC        
        
        GO
  