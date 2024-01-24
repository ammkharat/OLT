if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdatePermitRequestTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdatePermitRequestTemplate]
GO

    
    
CREATE Procedure [dbo].[UpdatePermitRequestTemplate]          
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
UPDATE PermitRequestTemplate       
SET 
TemplateName = @TemplateName ,
Categories = @Categories,
[Global] = @Global ,
Individual = @Individual ,
LastModifiedByUserId = @LastModifiedUserId ,
LastModifiedDateTime = @LastModifiedDateTime
     
 WHERE TemplateId=@Id  
    
 
        
OPTION (OPTIMIZE FOR UNKNOWN)  


GRANT EXEC ON UpdatePermitRequestTemplate TO PUBLIC
GO
  