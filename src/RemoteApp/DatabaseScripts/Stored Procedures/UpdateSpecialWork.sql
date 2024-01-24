IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSpecialWork')
	BEGIN
		DROP Procedure [dbo].UpdateSpecialWork
	END
GO

CREATE Procedure [dbo].[UpdateSpecialWork]    
 (    
     @Id BIGINT,    
  @CompanyName VARCHAR(50),    
  @SiteId BIGINT    
 )    
    
AS    
 UPDATE SpecialWork     
 SET     
     CompanyName = @CompanyName,     
     SiteId = @SiteId     
 WHERE Id = @Id 
 
 GO

GRANT EXEC ON UpdateSpecialWork TO PUBLIC
GO 
 
 