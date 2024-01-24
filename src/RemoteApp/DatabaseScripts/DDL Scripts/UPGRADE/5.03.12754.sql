
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






GO



IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[LOGImages]') AND type in (N'U'))

BEGIN
Create table LOGImages
(
   ID bigint identity(1,1)
  ,LOGID bigint NOT NULL
  ,Name Varchar(50)
  ,[Description] Varchar(150)
  ,ImagePath Varchar(150)
  ,CreatedDate datetime
  ,Createdby Int
  ,Updateddate datetime
  ,UpdatedBy datetime
  ,RecordType int
  ,RecordFor int default(0)
  
)
END



GO

