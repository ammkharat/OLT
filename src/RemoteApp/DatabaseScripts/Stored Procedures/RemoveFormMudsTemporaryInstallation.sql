if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveFormMudsTemporaryInstallation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveFormMudsTemporaryInstallation]
GO
  
CREATE Procedure [dbo].[RemoveFormMudsTemporaryInstallation]  
 (  
  @id bigint,  
  @LastModifiedByUserId bigint,   
  @LastModifiedDateTime datetime  
 )  
AS  
  
UPDATE  FormMudsTemporaryInstallation  
 SET LastModifiedByUserId = @LastModifiedByUserId,  
  LastModifiedDateTime = @LastModifiedDateTime,  
  Deleted = 1  
 WHERE Id=@Id 
 
 
 
GRANT EXEC ON RemoveFormMudsTemporaryInstallation TO PUBLIC
GO 