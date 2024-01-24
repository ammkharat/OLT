if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveAdminMember]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveAdminMember]
GO
          
CREATE Procedure dbo.RemoveAdminMember   
 (    
 @Id bigint    
 )    
AS    
    
UPDATE OLTAdministrator    
 SET Deleted = 1    
 WHERE Id = @Id 
 GO

GRANT EXEC ON RemoveAdminMember TO PUBLIC
GO  