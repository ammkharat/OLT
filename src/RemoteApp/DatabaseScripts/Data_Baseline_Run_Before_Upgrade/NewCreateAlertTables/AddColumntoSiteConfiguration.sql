
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'AllowToDisplayActionItemTitleOnPriorityPage'
)
BEGIN
ALTER TABLE SiteConfiguration ADD AllowToDisplayActionItemTitleOnPriorityPage BIT NOT NULL DEFAULT '0'
END



IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'AllowToDisplayEveryShiftOnActionItemDefinitionForm'
)
BEGIN
ALTER TABLE SiteConfiguration ADD AllowToDisplayEveryShiftOnActionItemDefinitionForm BIT NOT NULL DEFAULT '0'
END



--Added for Log IMage enable and Path

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'LogImagePath'
)
BEGIN
ALTER TABLE SiteConfiguration ADD LogImagePath varchar(500)  NULL 
END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'EnableLogImage'
)
BEGIN
ALTER TABLE SiteConfiguration ADD EnableLogImage bit  default(0) 
END


---Added EnableRoundInfo Column

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'EnableRoundInfo'
)
BEGIN
ALTER TABLE SiteConfiguration ADD EnableRoundInfo bit  default(0) 
END

