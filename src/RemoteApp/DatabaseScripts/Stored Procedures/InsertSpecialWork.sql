IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSpecialWork')
	BEGIN
		DROP Procedure [dbo].InsertSpecialWork
	END
GO


CREATE Procedure [dbo].[InsertSpecialWork]    
 (    
     @Id BIGINT OUTPUT,    
  @CompanyName VARCHAR(50),    
  @SiteId BIGINT    
 )    
AS    
 INSERT INTO SpecialWork    
 (    
     CompanyName,    
     SiteId    
 )    
 VALUES    
 (    
  @CompanyName,    
  @SiteId    
 )    
SET @Id = SCOPE_IDENTITY() 
Go

GRANT EXEC ON InsertSpecialWork TO PUBLIC
GO 

