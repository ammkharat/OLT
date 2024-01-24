if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPermitRequestTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertPermitRequestTemplate]
GO


CREATE Procedure [dbo].[InsertPermitRequestTemplate]      
(      
    @Id bigint,        
 @TemplateName varchar(100),    
 @IsTemplate bit,     
 @CreatedByUser varchar(100) ,   
 @Categories varchar(100) ,   
 --@FunctionalLocationId bigint,    
 @Description varchar(400) ,    
 @WorkPermitType varchar(100) ,     
 @Global bit,    
 @Individual bit,    
 @SiteId bigint      
     
       
)    
 AS    
    
 INSERT INTO PermitRequestTemplate    
 (     
 Id,     
 TemplateName ,    
 IsTemplate ,     
 CreatedByUser ,     
 SiteId ,    
 Categories,    
 Description,    
 --FunctionalLocationId,    
 WorkPermitType,    
 Global ,    
 Individual ,    
 Deleted      
     
 )    
 VALUES    
    
 (    
 @Id,     
 @TemplateName ,    
 @IsTemplate ,     
 @CreatedByUser ,     
 @SiteId ,    
 @Categories,  
 @Description ,    
 --@FunctionalLocationId,    
 @WorkPermitType ,    
 @Global ,    
 @Individual ,    
 0    
 )    

OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON InsertPermitRequestTemplate TO PUBLIC
GO
