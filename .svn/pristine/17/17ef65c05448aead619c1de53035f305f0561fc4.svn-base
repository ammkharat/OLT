IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GETWORKPERMITSIGN')
	BEGIN
		DROP PROCEDURE [dbo].[GETWORKPERMITSIGN]
	END
	
GO
CREATE Procedure [dbo].[GETWORKPERMITSIGN]    
(    
 @WorkPermitId Varchar(100),
 @SiteId Int

 
     
)    
AS    
    

 
 SELECT * FROM  WORKPERMITSIGN WHERE WorkPermitId=@WorkPermitId and SiteId=@SiteId
 
    
GRANT EXEC ON [GETWORKPERMITSIGN] TO PUBLIC       