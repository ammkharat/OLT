IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75B]') 
         AND name = 'TemplateID'
)
BEGIN
Alter table FormGN75B add [TemplateID]  [bigint]
END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75B]') 
         AND name = 'DeadLeg'
)
BEGIN
ALTER TABLE FormGN75B ADD DeadLeg BIT NOT NULL DEFAULT '0'
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75B]') 
         AND name = 'SpecialPrecautions'
)
BEGIN
ALTER TABLE FormGN75B ADD SpecialPrecautions varchar(250) NULL DEFAULT null
END
go



GO

