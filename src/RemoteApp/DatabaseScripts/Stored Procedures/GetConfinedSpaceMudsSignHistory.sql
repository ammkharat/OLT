if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetConfinedSpaceMudsSignHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetConfinedSpaceMudsSignHistory]
Go
CREATE Procedure [dbo].[GetConfinedSpaceMudsSignHistory]      
(      
 @ConfinedSpaceId Varchar(100)  
  
   
       
)      
AS      
   
 SELECT * FROM  ConfinedSpaceMudssignHistory WHERE ConfinedSpaceId =@ConfinedSpaceId  
 UNION ALL  
SELECT * FROM  ConfinedSpaceMudssign WHERE ConfinedSpaceId=@ConfinedSpaceId  
   
   
      
GRANT EXEC ON [GetConfinedSpaceMudsSignHistory] TO PUBLIC         