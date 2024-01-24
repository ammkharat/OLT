IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'EnableCSDMarkAsRead'
)
BEGIN
ALTER TABLE SiteConfiguration ADD EnableCSDMarkAsRead BIT NOT NULL DEFAULT '0'
END