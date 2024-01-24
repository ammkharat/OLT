IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveSpecialWork')
	BEGIN
		DROP Procedure [dbo].RemoveSpecialWork
	END
GO

CREATE Procedure [dbo].[RemoveSpecialWork]    
 (    
  @Id BIGINT    
 )    
AS    
 DELETE FROM SpecialWork WHERE Id = @Id  
 
 GO

GRANT EXEC ON RemoveSpecialWork TO PUBLIC
GO