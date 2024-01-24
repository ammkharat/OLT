  
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveRole')  

        BEGIN 
                DROP PROCEDURE [dbo].RemoveRole
        END 
GO

CREATE Procedure [dbo].[RemoveRole]      
 (      
  @Id BIGINT      
 )      
AS      

BEGIN
	 UPdate DBO.[ROLE] 
	 SET
	 deleted=1
	 WHERE Id = @Id   
 
 END 
 
 
GRANT EXEC ON RemoveRole TO PUBLIC 
GO 