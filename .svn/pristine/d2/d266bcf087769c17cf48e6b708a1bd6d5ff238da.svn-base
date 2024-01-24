if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAdminMember]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertAdminMember]
GO
              
CREATE Procedure dbo.InsertAdminMember        
 (          
   
 @SiteName VARCHAR(50)  ,        
 @Group VARCHAR(100)  ,        
 @SiteAdmin VARCHAR(100)  ,        
 @SiteRepresentative VARCHAR(100)  ,        
 @BEA VARCHAR(100)           
 )          
AS          
          
INSERT INTO OLTAdministrator          
 (          
        
[SiteName],        
[Group],        
[SiteRepresentative],        
[SiteAdmin],        
[BEA]        
  )          
VALUES          
  (          
       
@SiteName,        
@Group,        
@SiteRepresentative,        
@SiteAdmin,        
@BEA         
)      
 
GO

GRANT EXEC ON InsertAdminMember TO PUBLIC
GO    

