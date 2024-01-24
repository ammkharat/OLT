if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateConfinedSpaceMudssign]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateConfinedSpaceMudssign]
Go  
Create Procedure [dbo].[InsertUpdateConfinedSpaceMudssign]        
(        
 @ConfinedSpaceId Varchar(100),    
 @Verifier_FNAME  Nvarchar(500),    
 @Verifier_LNAME   Nvarchar(500),    
 @Verifier_BADGENUMBER NVARCHAR(100),    
 @Verifier_BADGETYPE VARCHAR(100),    
 @Verifier_SOURCE   VARCHAR(100),    
 @DETENTEUR_FNAME  Nvarchar(500),    
 @DETENTEUR_LNAME  Nvarchar(500),    
 @DETENTEUR_BADGENUMBER NVARCHAR(100),    
 @DETENTEUR_BADGETYPE VARCHAR(100),    
 @DETENTEUR_SOURCE VARCHAR(100),    
 @EMETTEUR_FNAME  Nvarchar(500),    
 @EMETTEUR_LNAME  Nvarchar(500),    
 @EMETTEUR_BADGENUMBER NVARCHAR(100),     
 @EMETTEUR_BADGETYPE VARCHAR(100),    
 @EMETTEUR_SOURCE VARCHAR(100),    
 @UpdatedBy INT,    
 @CreatedBy INT,    
 @CreatedDate Datetime,    
 @UpdatedDate Datetime,    
 @SiteId Int ,  
    
 @FirstNameFirstResult Nvarchar(100)=Null,  
 @LasttNameFirstResult Nvarchar(100)=Null,  
 @SourceFirstResult Nvarchar(100)=Null,  
 @BadgeFirstResult Nvarchar(100)=Null,  
 @FirstNameSecondResult Nvarchar(100)=Null,  
 @LasttNameSecondResult Nvarchar(100)=Null,  
 @SourceSecondResult Nvarchar(100)=Null,  
 @BadgeSecondResult Nvarchar(100)=Null,  
 @FirstNameThirdResult Nvarchar(100)=Null,  
 @LasttNameThirdResult Nvarchar(100)=Null,  
 @SourceThirdResult Nvarchar(100)=Null,  
 @BadgeThirdResult Nvarchar(100)=Null,  
 @FirstNameFourthResult Nvarchar(100)=Null,  
 @LasttNameFourthResult Nvarchar(100)=Null,  
 @SourceFourthResult Nvarchar(100)=Null,  
 @BadgeFourthResult Nvarchar(100)=Null  
           
)        
AS        
        
 if EXISTS(Select * from ConfinedSpaceMudssign WHERE ConfinedSpaceId=@ConfinedSpaceId)     
 BEGIN    
     
 -----------START HISTORY--------------------------    
 INSERT INTO ConfinedSpaceMudssignHistory    
 (    
  ConfinedSpaceId ,    
  Verifier_FNAME  ,    
  Verifier_LNAME  ,    
  Verifier_BADGENUMBER ,    
  Verifier_BADGETYPE ,    
  Verifier_SOURCE   ,    
  DETENTEUR_FNAME ,    
  DETENTEUR_LNAME,    
  DETENTEUR_BADGENUMBER,    
  DETENTEUR_BADGETYPE,    
  DETENTEUR_SOURCE ,    
  EMETTEUR_FNAME,    
  EMETTEUR_LNAME,    
  EMETTEUR_BADGENUMBER,     
  EMETTEUR_BADGETYPE,    
  EMETTEUR_SOURCE,    
  UpdatedBy ,    
  CreatedBy ,    
  CreatedDate ,    
  UpdatedDate ,    
  SiteId ,  
 FirstNameFirstResult ,  
 LasttNameFirstResult ,  
 SourceFirstResult ,  
 BadgeFirstResult ,  
 FirstNameSecondResult,   
 LasttNameSecondResult ,  
 SourceSecondResult ,  
 BadgeSecondResult ,  
 FirstNameThirdResult,   
 LasttNameThirdResult,   
 SourceThirdResult ,  
 BadgeThirdResult ,  
 FirstNameFourthResult,   
 LasttNameFourthResult ,  
 SourceFourthResult ,  
 BadgeFourthResult  )    
      
SELECT     
  ConfinedSpaceId ,    
  Verifier_FNAME  ,    
  Verifier_LNAME  ,    
  Verifier_BADGENUMBER ,    
  Verifier_BADGETYPE ,    
  Verifier_SOURCE   ,    
  DETENTEUR_FNAME ,    
  DETENTEUR_LNAME,    
  DETENTEUR_BADGENUMBER,    
  DETENTEUR_BADGETYPE,    
  DETENTEUR_SOURCE ,    
  EMETTEUR_FNAME,    
  EMETTEUR_LNAME,    
  EMETTEUR_BADGENUMBER,     
  EMETTEUR_BADGETYPE,    
  EMETTEUR_SOURCE,    
  UpdatedBy ,    
  CreatedBy ,    
  CreatedDate ,    
  UpdatedDate ,    
  SiteId   ,  
  FirstNameFirstResult ,  
 LasttNameFirstResult ,  
 SourceFirstResult ,  
 BadgeFirstResult ,  
 FirstNameSecondResult,   
 LasttNameSecondResult ,  
 SourceSecondResult ,  
 BadgeSecondResult ,  
 FirstNameThirdResult,   
 LasttNameThirdResult,   
 SourceThirdResult ,  
 BadgeThirdResult ,  
 FirstNameFourthResult,   
 LasttNameFourthResult ,  
 SourceFourthResult ,  
 BadgeFourthResult  
 FROM ConfinedSpaceMudssign    
 WHERE ConfinedSpaceId=@ConfinedSpaceId    
      
 ----------End HIstory-----------    
     
 UPDATE ConfinedSpaceMudssign    
 SET    
      
 Verifier_FNAME=@Verifier_FNAME  ,    
 Verifier_LNAME=@Verifier_LNAME  ,    
 Verifier_BADGENUMBER=@Verifier_BADGENUMBER ,    
 Verifier_BADGETYPE=@Verifier_BADGETYPE ,    
 Verifier_SOURCE=@Verifier_SOURCE   ,    
     
 DETENTEUR_FNAME=@DETENTEUR_FNAME ,    
 DETENTEUR_LNAME=@DETENTEUR_LNAME,    
 DETENTEUR_BADGENUMBER=@DETENTEUR_BADGENUMBER,    
 DETENTEUR_BADGETYPE=@DETENTEUR_BADGETYPE,    
 DETENTEUR_SOURCE=@DETENTEUR_SOURCE ,    
     
 EMETTEUR_FNAME=@EMETTEUR_FNAME,    
 EMETTEUR_LNAME=@EMETTEUR_LNAME,    
 EMETTEUR_BADGENUMBER=@EMETTEUR_BADGENUMBER,     
 EMETTEUR_BADGETYPE=@EMETTEUR_BADGETYPE,    
 EMETTEUR_SOURCE=@EMETTEUR_SOURCE,    
     
     
 UpdatedBy=@UpdatedBy,    
 CreatedBy=@CreatedBy,    
 CreatedDate=@CreatedDate,    
 UpdatedDate=@UpdatedDate,    
 SiteId=@SiteId  ,  
   
 FirstNameFirstResult=@FirstNameFirstResult ,  
 LasttNameFirstResult=@LasttNameFirstResult ,  
 SourceFirstResult=@SourceFirstResult ,  
 BadgeFirstResult=@BadgeFirstResult ,  
 FirstNameSecondResult=@FirstNameSecondResult,   
 LasttNameSecondResult=@LasttNameSecondResult ,  
 SourceSecondResult=@SourceSecondResult ,  
 BadgeSecondResult=@BadgeSecondResult ,  
 FirstNameThirdResult=@FirstNameThirdResult,   
 LasttNameThirdResult=@LasttNameThirdResult,   
 SourceThirdResult=@SourceThirdResult ,  
 BadgeThirdResult=@BadgeThirdResult ,  
 FirstNameFourthResult=@FirstNameFourthResult,   
 LasttNameFourthResult=@LasttNameFourthResult ,  
 SourceFourthResult=@SourceFourthResult ,  
 BadgeFourthResult=@BadgeFourthResult  
   
 WHERE ConfinedSpaceId=@ConfinedSpaceId     
     
 UPdate ConfinedSpaceMudssign    
  SET Deleted=0 where ConfinedSpaceId=@ConfinedSpaceId  
     
 END    
 ELSE    
 BEGIN    
 INSERT ConfinedSpaceMudssign    
 (    
  ConfinedSpaceId,    
     
 Verifier_FNAME  ,    
 Verifier_LNAME  ,    
 Verifier_BADGENUMBER ,    
 Verifier_BADGETYPE ,    
 Verifier_SOURCE   ,    
     
 DETENTEUR_FNAME ,    
 DETENTEUR_LNAME,    
 DETENTEUR_BADGENUMBER,    
 DETENTEUR_BADGETYPE,    
 DETENTEUR_SOURCE ,    
     
 EMETTEUR_FNAME,    
 EMETTEUR_LNAME,    
 EMETTEUR_BADGENUMBER,     
 EMETTEUR_BADGETYPE,    
 EMETTEUR_SOURCE,    
     
 UpdatedBy ,    
 CreatedBy ,    
 CreatedDate ,    
 UpdatedDate ,    
 SiteId ,  
 FirstNameFirstResult ,  
 LasttNameFirstResult ,  
 SourceFirstResult ,  
 BadgeFirstResult ,  
 FirstNameSecondResult,   
 LasttNameSecondResult ,  
 SourceSecondResult ,  
 BadgeSecondResult ,  
 FirstNameThirdResult,   
 LasttNameThirdResult ,  
 SourceThirdResult ,  
 BadgeThirdResult ,  
 FirstNameFourthResult,   
 LasttNameFourthResult ,  
 SourceFourthResult ,  
 BadgeFourthResult   
 )    
     
 Values    
 (    
  @ConfinedSpaceId ,    
      
 @Verifier_FNAME  ,    
 @Verifier_LNAME  ,    
 @Verifier_BADGENUMBER ,    
 @Verifier_BADGETYPE ,    
 @Verifier_SOURCE   ,    
     
 @DETENTEUR_FNAME ,    
 @DETENTEUR_LNAME,    
 @DETENTEUR_BADGENUMBER,    
 @DETENTEUR_BADGETYPE,    
 @DETENTEUR_SOURCE ,    
     
 @EMETTEUR_FNAME,    
 @EMETTEUR_LNAME,    
 @EMETTEUR_BADGENUMBER,     
 @EMETTEUR_BADGETYPE,    
 @EMETTEUR_SOURCE,    
     
 @UpdatedBy ,    
 @CreatedBy ,    
 @CreatedDate ,    
 @UpdatedDate ,    
 @SiteId   ,  
 @FirstNameFirstResult ,  
 @LasttNameFirstResult ,  
 @SourceFirstResult ,  
 @BadgeFirstResult ,  
 @FirstNameSecondResult,   
 @LasttNameSecondResult ,  
 @SourceSecondResult ,  
 @BadgeSecondResult ,  
 @FirstNameThirdResult,   
 @LasttNameThirdResult ,  
 @SourceThirdResult ,  
 @BadgeThirdResult ,  
 @FirstNameFourthResult,   
 @LasttNameFourthResult ,  
 @SourceFourthResult ,  
 @BadgeFourthResult   
 )    
 END      
    
        
GRANT EXEC ON [InsertUpdateConfinedSpaceMudssign] TO PUBLIC           