IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertRoadAccessOnPermit')
	BEGIN
		DROP  Procedure  InsertRoadAccessOnPermit
	END

GO
  
Create Procedure [dbo].[InsertRoadAccessOnPermit]  
 (  
 @Id bigint Output,  
 @Name varchar(50),  
 @WorkCenter varchar(10) = null,  
 @SiteId bigint  
 )  
AS  
  
INSERT INTO RoadAccessOnPermit ([Name], WorkCenter, SiteId)  
VALUES     (@Name, @WorkCenter, @SiteId)  
  
  
SET @Id= SCOPE_IDENTITY()   



GRANT EXEC ON InsertRoadAccessOnPermit TO PUBLIC        
        
        GO