
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryConfinedSpaceMudsByConfinedSpaceId')
	BEGIN
		DROP Procedure [dbo].QueryConfinedSpaceMudsByConfinedSpaceId
	END
GO

  
Create Procedure [dbo].[QueryConfinedSpaceMudsByConfinedSpaceId]  
(  
 @Id bigint  
)  
AS  
 SELECT   
  *   
 From   
  ConfinedSpaceMuds  
 WHERE  
  ConfinedSpaceMuds.ConfinedSpaceNumber = @Id  
  
  
GRANT EXEC ON QueryConfinedSpaceMudsByConfinedSpaceId TO PUBLIC
GO

  