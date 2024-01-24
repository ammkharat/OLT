
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'AllowEditingOfOldLogs'
)
BEGIN
ALTER TABLE SiteConfiguration ADD AllowEditingOfOldLogs BIT NOT NULL DEFAULT '0'
END

--DMND0010303 by ppanigrahi

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ShiftHandoverQuestion]') 
         AND name = 'EmailList'
)
BEGIN
ALTER TABLE ShiftHandoverQuestion ADD EmailList varchar(500) 
END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ShiftHandoverQuestion]') 
         AND name = 'YesNo'
)
BEGIN
ALTER TABLE ShiftHandoverQuestion ADD YesNo varchar(50) 
END


GO

