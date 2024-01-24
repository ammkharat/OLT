IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CheckWorkPermitExist')
	BEGIN
		DROP PROCEDURE [dbo].CheckWorkPermitExist
	END
	
GO
CREATE  Procedure [dbo].[CheckWorkPermitExist]  
(  
  @PermitNumber Varchar(50),  
  @SiteId Int  
   
)  
AS  
  
if(@SiteId=8)    
BEGIN    
    
select ISNUll(Id,0) from WorkPermitEdmonton where CAST(PermitNumber AS Varchar)=@PermitNumber    
END    
ELSE if(@SiteId=1 OR @SiteId=2)    
BEGIN    
    
select ISNUll(Id,0) from WorkPermit where CAST(PermitNumber AS Varchar)=@PermitNumber    
END   
ELSE if(@SiteId=16)    
BEGIN    
    
select ISNUll(Id,0) from WorkPermitMuds where CAST(PermitNumber AS Varchar)=@PermitNumber    
END  
ELSE if(@SiteId=9)    
BEGIN    
    
select ISNUll(Id,0) from WorkPermitMontreal where CAST(PermitNumber AS Varchar)=@PermitNumber    
END  
ELSE    
 BEGIN    
 Select 0    
 END    
    

  
GRANT EXEC ON CheckWorkPermitExist TO PUBLIC     
  
  
  
  
  
  

