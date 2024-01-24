  
    
    
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveUserPrintPreference')
    BEGIN
        DROP PROCEDURE [dbo].RemoveUserPrintPreference
    END
GO  
  
  
CREATE Procedure [dbo].RemoveUserPrintPreference  
 (  
  @id bigint  
 )  
AS  
  
DELETE FROM UserPrintPreference WHERE Id = @id  


GRANT EXEC ON RemoveUserPrintPreference TO PUBLIC