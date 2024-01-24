  
  /*
  Created By:-IBM
  Created Date:-28 Dec 2017
  Created For:-New Role Add/Edit form
  
  */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateRole')  

        BEGIN 
                DROP PROCEDURE [dbo].[UpdateRole] 
        END 
GO



CREATE Procedure [dbo].[UpdateRole]      
 (  
 @Name VARCHAR(50)
,@ActiveDirectoryKey VARCHAR(255)
,@IsAdministratorRole bit
,@IsReadOnlyRole bit
,@IsWorkPermitNonOperationsRole bit 
,@WarnIfWorkAssignmentNotSelected bit
,@IsDefaultReadOnlyRoleForSite bit
,@SiteId BIGINT  
,@Alias  Varchar(40) 
,@Id BIGINT
 )      
AS   
BEGIN

	UPDATE [DBO].[ROLE]
	 SET
	 [Name] =@Name
	,ActiveDirectoryKey=@ActiveDirectoryKey
	,IsAdministratorRole=@IsAdministratorRole 
	,IsReadOnlyRole=@IsReadOnlyRole 
	,IsWorkPermitNonOperationsRole=@IsWorkPermitNonOperationsRole 
	,WarnIfWorkAssignmentNotSelected =@WarnIfWorkAssignmentNotSelected
	,IsDefaultReadOnlyRoleForSite =@IsDefaultReadOnlyRoleForSite
	,Alias  =@Alias 
	,SiteId=@SiteId  
	 WHERE ID=@id 
          
	 
 
 
 END


GRANT EXEC ON UpdateRole TO PUBLIC 
GO 

