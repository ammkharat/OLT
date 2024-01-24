IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SelectUserID')
	BEGIN
		DROP PROCEDURE [dbo].SelectUserID
	END
GO
 CREATE Procedure [dbo].[SelectUserID]    
 (      
    @UserName varchar(30)     
 )    
AS    
 SELECT U.Id from   [User] U    
 Where U.Username=@UserName   
    
GRANT EXEC ON SelectUserID TO PUBLIC 