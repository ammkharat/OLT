if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGenericTemplateApprover]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGenericTemplateApprover]
GO  
    
    
Create Procedure [dbo].[InsertFormGenericTemplateApprover]        
 (        
     @Id BIGINT OUTPUT,      
  @FormTypeId BIGINT  ,    
  @Name NVARCHAR(100),        
  @SiteId BIGINT  ,  
  @PlantId BIGINT        
 )        
AS        
 INSERT INTO FormGenericTemplateApprover        
 (        
     FormTypeID,   
     Name,  
     SiteID,       
     PlantID        
 )        
 VALUES        
 (        
  @FormTypeId,        
  @Name,    
  @SiteId,  
  @PlantId        
 )        
SET @Id = SCOPE_IDENTITY() 


GRANT EXEC ON InsertFormGenericTemplateApprover TO PUBLIC
GO