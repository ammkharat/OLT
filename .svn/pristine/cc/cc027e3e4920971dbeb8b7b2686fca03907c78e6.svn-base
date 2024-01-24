if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetConfinedSpaceMudssign]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetConfinedSpaceMudssign]
Go

CREATE Procedure [dbo].[GetConfinedSpaceMudssign]      
(      
 @ConfinedSpaceId Varchar(100),  
 @SiteId Int=NULL  
  
   
       
)      
AS      
      
SELECT * FROM  ConfinedSpaceMudssign WHERE ConfinedSpaceId=@ConfinedSpaceId and Deleted=0  
   
      
GRANT EXEC ON [GetConfinedSpaceMudssign] TO PUBLIC         