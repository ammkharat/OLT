
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserMarkedFormOP14AsRead')
    BEGIN
        DROP PROCEDURE [dbo].QueryUserMarkedFormOP14AsRead
    END
GO

 --INC0458345(ppanigrahi) comment Inner join on shift id to remove shift information.     
CREATE Procedure [dbo].[QueryUserMarkedFormOP14AsRead]        
(        
 @FormOP14Id bigint,        
 @UserId bigint =null,
 @ShiftId  bigint  
)        
AS        
        
SELECT [User].Username,  
[User].Firstname,  
[User].Lastname,  
Fop14.DateTime--, shft.Name        
 FROM [FormOP14Read] Fop14      
 INNER JOIN [User] ON Fop14.UserId = [User].Id
  --INNER JOIN Shift shft ON Fop14.ShiftId = shft.Id        
WHERE        
 FormOP14Id = @FormOP14Id AND        
 (@UserId IS NULL OR Fop14.UserId = @UserId) AND Fop14.Deleted = 0 --AND  Fop14.ShiftId = @ShiftId    
       
   
 
 GRANT EXEC ON QueryUserMarkedFormOP14AsRead TO PUBLIC
GO 