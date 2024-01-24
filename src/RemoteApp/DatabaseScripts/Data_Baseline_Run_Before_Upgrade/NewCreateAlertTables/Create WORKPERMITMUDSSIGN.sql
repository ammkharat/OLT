

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') AND type in (N'U'))
BEGIN
Create TABLE WORKPERMITMUDSSIGN
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
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'FirstNameFirstResult'
)
begin

ALTER TABLE dbo.WORKPERMITMUDSSIGN Add FirstNameFirstResult Nvarchar(100)

 
 END
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'LasttNameFirstResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add LasttNameFirstResult Nvarchar(100)
 End
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'SourceFirstResult'
)
begin
 
 ALTER TABLE dbo.WORKPERMITMUDSSIGN Add SourceFirstResult Nvarchar(100)
 
 End
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'BadgeFirstResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add BadgeFirstResult Nvarchar(100)
 
 End
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'FirstNameSecondResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add FirstNameSecondResult Nvarchar(100)
 
 End
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'LasttNameSecondResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add LasttNameSecondResult Nvarchar(100)
 
 End
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'SourceSecondResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add SourceSecondResult Nvarchar(100)
 end
 
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'BadgeSecondResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add BadgeSecondResult Nvarchar(100)
 
 end
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'FirstNameThirdResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add FirstNameThirdResult Nvarchar(100)
 
 end
 
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'LasttNameThirdResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add LasttNameThirdResult Nvarchar(100)
 
 end
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'SourceThirdResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add SourceThirdResult Nvarchar(100)
 
 end
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'BadgeThirdResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add BadgeThirdResult Nvarchar(100)
 
 end
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'FirstNameFourthResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add FirstNameFourthResult Nvarchar(100)
 
 end
 
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'LasttNameFourthResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add LasttNameFourthResult Nvarchar(100)
 
 end
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'SourceFourthResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add SourceFourthResult Nvarchar(100)
 
 end
 
 
 
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WORKPERMITMUDSSIGN]') 
         AND name = 'BadgeFourthResult'
)
begin
 
  ALTER TABLE dbo.WORKPERMITMUDSSIGN Add BadgeFourthResult Nvarchar(100)
   end     
            
            
        
      

