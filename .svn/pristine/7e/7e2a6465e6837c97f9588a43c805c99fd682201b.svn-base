if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateWorkPermitTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateWorkPermitTemplate]
GO

    
CREATE Procedure [dbo].[UpdateWorkPermitTemplate]          
(          
          
  @id bigint,     
 @TemplateName varchar(100),  
 @Categories varchar(100) , 
 @Global bit,        
 @Individual bit,         
 @LastModifiedUserId bigint,       
 @LastModifiedDateTime datetime           
         
           
)        
 AS        
UPDATE WorkPermitTemplate       
SET 
TemplateName = @TemplateName ,
Categories = @Categories,
[Global] = @Global ,
Individual = @Individual ,
LastModifiedByUserId = @LastModifiedUserId ,
LastModifiedDateTime = @LastModifiedDateTime
     
 WHERE TemplateId=@Id  
    
 
        
OPTION (OPTIMIZE FOR UNKNOWN)  


GRANT EXEC ON UpdateWorkPermitTemplate TO PUBLIC
GO
  