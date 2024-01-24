if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertWorkPermitTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertWorkPermitTemplate]
GO  
  
CREATE Procedure [dbo].[InsertWorkPermitTemplate]        
(        
    @Id bigint,      
    @PermitNumber varchar(50),      
 @TemplateName varchar(100),      
 @IsTemplate bit,       
 @CreatedByUser varchar(100) ,   
@Categories varchar(100) ,   
 @Description varchar(400) ,      
 @WorkPermitType varchar(100) ,      
 @Global bit,      
 @Individual bit,       
 @SiteId bigint        
       
         
)      
 AS      
      
 INSERT INTO WorkPermitTemplate      
 (       
 Id,      
 PermitNumber ,      
 TemplateName ,      
 IsTemplate ,       
 CreatedByUser ,       
 SiteId ,      
 Categories,      
 Description,      
 WorkPermitType,      
 Global ,      
 Individual ,      
 Deleted        
       
 )      
 VALUES      
      
 (      
 @Id,      
 @PermitNumber ,      
 @TemplateName ,      
 @IsTemplate ,       
 @CreatedByUser ,        
 @SiteId ,      
 @Categories,   
 @Description ,      
 @WorkPermitType ,      
 @Global ,      
 @Individual ,      
 0      
 )      
      
OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON InsertWorkPermitTemplate TO PUBLIC
GO

       
      
        
      