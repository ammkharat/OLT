
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserMarkedFormOP14AsReadOnPriorityPage')
    BEGIN
        DROP PROCEDURE [dbo].QueryUserMarkedFormOP14AsReadOnPriorityPage
    END
GO

   
 --Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD 


CREATE Procedure [dbo].[QueryUserMarkedFormOP14AsReadOnPriorityPage]        
(        
 @FormOP14Id bigint,        
 @UserId bigint =null,
 @ShiftId  bigint  ,
 @currentDate Date
)        
AS        
        
SELECT [User].Username,  
[User].Firstname,  
[User].Lastname,  
Fop14.DateTime, shft.Name        
 FROM [FormOP14Read] Fop14      
 INNER JOIN [User] ON Fop14.UserId = [User].Id
  INNER JOIN Shift shft ON Fop14.ShiftId = shft.Id        
WHERE        
 FormOP14Id = @FormOP14Id AND        
 (@UserId IS NULL OR Fop14.UserId = @UserId) AND Fop14.Deleted = 0 AND  Fop14.ShiftId = @ShiftId    
 AND  (select CAST(Fop14.DateTime AS DATE)) = CAST(@currentDate AS DATE)
       
   
 
 GRANT EXEC ON QueryUserMarkedFormOP14AsReadOnPriorityPage TO PUBLIC
GO 