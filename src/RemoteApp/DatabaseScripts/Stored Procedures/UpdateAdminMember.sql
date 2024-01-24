if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAdminMember]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateAdminMember]
GO
        
CREATE Procedure dbo.UpdateAdminMember        
 (        
       
 @SiteName VARCHAR(50)  ,      
 @Group VARCHAR(100)  ,      
 @SiteAdmin VARCHAR(100)  ,      
 @SiteRepresentative VARCHAR(100)  ,      
 @BEA VARCHAR(100) ,       
  @Id bigint        
 )        
        
AS        
UPDATE OLTAdministrator        
 SET         
        
[SiteName]= @SiteName,      
[Group] = @Group,      
[SiteRepresentative] = @SiteRepresentative,      
[SiteAdmin] = @SiteAdmin,      
[BEA]=@BEA      
WHERE        
Id = @Id 

GO

GRANT EXEC ON UpdateAdminMember TO PUBLIC
GO    

