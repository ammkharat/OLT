  
  /*
  Created By:-IBM
  Created Date:-28 Dec 2017
  Created For:-New Role Add/Edit form
  
  */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertRole')  

        BEGIN 
                DROP PROCEDURE [dbo].[InsertRole] 
        END 
GO



CREATE Procedure [dbo].[InsertRole]      
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
,@Id BIGINT=NULL
 )      
AS   

BEGIN
 INSERT INTO [DBO].[ROLE]      
	 (      
	 [Name]
	,ActiveDirectoryKey 
	,IsAdministratorRole 
	,IsReadOnlyRole 
	,IsWorkPermitNonOperationsRole 
	,WarnIfWorkAssignmentNotSelected
	,IsDefaultReadOnlyRoleForSite
	,Alias
	,SiteId      
	 )      
	 VALUES      
	 (      
	  @Name 
	,@ActiveDirectoryKey 
	,@IsAdministratorRole 
	,@IsReadOnlyRole 
	,@IsWorkPermitNonOperationsRole 
	,@WarnIfWorkAssignmentNotSelected
	,@IsDefaultReadOnlyRoleForSite
	,@Alias
	,@SiteId     
	 )               
	 
 
 
 END
    
   

GRANT EXEC ON InsertRole TO PUBLIC 
GO 

