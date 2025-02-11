if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGenericTemplateApprover]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGenericTemplateApprover]
GO  
 
CREATE Procedure [dbo].[UpdateFormGenericTemplateApprover]      
 (      
     @Id BIGINT,      
     @Name NVARCHAR(100),
     @FormTypeId BIGINT,
	 @PlantId BIGINT,
	 @SiteId BIGINT   --//added three more  parameter for future reference.  
     
 )      
      
AS      
 UPDATE FormGenericTemplateApprover       
 SET       
     Name = @Name        
 WHERE Id = @Id   
 
 