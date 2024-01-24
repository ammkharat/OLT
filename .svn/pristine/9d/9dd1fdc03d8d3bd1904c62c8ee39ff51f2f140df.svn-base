

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') AND type in (N'U'))
BEGIN
Create TABLE WORKPERMITMUDSSIGN_HISTORY
(
 ID bigint Identity(1,1),
 WorkPermitId Varchar(100),
 Verifier_FNAME  Nvarchar(500),
 Verifier_LNAME   Nvarchar(500),
 Verifier_BADGENUMBER NVARCHAR(100),
 Verifier_BADGETYPE VARCHAR(100),
 Verifier_SOURCE   VARCHAR(100),
 DETENTEUR_FNAME  Nvarchar(500),
 DETENTEUR_LNAME  Nvarchar(500),
 DETENTEUR_BADGENUMBER NVARCHAR(100),
 DETENTEUR_BADGETYPE VARCHAR(100),
 DETENTEUR_SOURCE VARCHAR(100),
 EMETTEUR_FNAME  Nvarchar(500),
 EMETTEUR_LNAME  Nvarchar(500),
 EMETTEUR_BADGENUMBER NVARCHAR(100), 
 EMETTEUR_BADGETYPE VARCHAR(100),
 EMETTEUR_SOURCE VARCHAR(100),
 Deleted bit default(0),
 UpdatedBy int,
 CreatedBy int,
 CreatedDate Datetime,
 UpdatedDate Datetime,
 SiteId Int,

 
 )
END



IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'FirstNameFirstResult'
)
begin

ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add FirstNameFirstResult Nvarchar(100)

 
 END
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'LasttNameFirstResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add LasttNameFirstResult Nvarchar(100)
 End
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'SourceFirstResult'
)
begin
 
 ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add SourceFirstResult Nvarchar(100)
 
 End
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'BadgeFirstResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add BadgeFirstResult Nvarchar(100)
 
 End
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'FirstNameSecondResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add FirstNameSecondResult Nvarchar(100)
 
 End
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'LasttNameSecondResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add LasttNameSecondResult Nvarchar(100)
 
 End
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'SourceSecondResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add SourceSecondResult Nvarchar(100)
 end
 
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'BadgeSecondResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add BadgeSecondResult Nvarchar(100)
 
 end
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'FirstNameThirdResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add FirstNameThirdResult Nvarchar(100)
 
 end
 
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'LasttNameThirdResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add LasttNameThirdResult Nvarchar(100)
 
 end
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'SourceThirdResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add SourceThirdResult Nvarchar(100)
 
 end
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'BadgeThirdResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add BadgeThirdResult Nvarchar(100)
 
 end
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'FirstNameFourthResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add FirstNameFourthResult Nvarchar(100)
 
 end
 
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'LasttNameFourthResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add LasttNameFourthResult Nvarchar(100)
 
 end
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'SourceFourthResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add SourceFourthResult Nvarchar(100)
 
 end
 
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN_HISTORY]') 
         AND name = 'BadgeFourthResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN_HISTORY Add BadgeFourthResult Nvarchar(100)
   end     
            
            
        
      

