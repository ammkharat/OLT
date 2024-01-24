IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormOP14EMail')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormOP14EMail
	END
GO
   
Create Procedure [dbo].[UpdateFormOP14EMail]    
(    
 @Id bigint,    
 @FormStatusId int,    
 @CriticalSystemDefeated varchar(255) = NULL,    
 @ApprovedDateTime datetime = NULL,     
 @LastModifiedByUserId bigint,    
 @LastModifiedDateTime datetime,    
 @siteid bigint    
)    
AS    
    
UPDATE FormOP14    
 SET     
  FormStatusId = @FormStatusId,      
  CriticalSystemDefeated = @CriticalSystemDefeated,      
  LastModifiedDateTime = @LastModifiedDateTime,    
  LastModifiedByUserId = @LastModifiedByUserId    
 WHERE    
  Id = @Id AND siteid = @siteid    
    
 GRANT EXEC ON [UpdateFormOP14EMail] TO PUBLIC
  
  
  
  