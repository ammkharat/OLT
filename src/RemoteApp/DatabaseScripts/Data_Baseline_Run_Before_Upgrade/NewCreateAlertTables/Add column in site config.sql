IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'SoundAlertforActionItemDirectiveEventsTargets'
)
BEGIN
ALTER TABLE SiteConfiguration ADD SoundAlertforActionItemDirectiveEventsTargets BIT NOT NULL DEFAULT '0'
END


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') AND name = 'EnableActionItemImage'
)
begin
ALTER TABLE SiteConfiguration ADD EnableActionItemImage Bit
end
Go



IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') AND name = 'EnableDirectiveImage'
)
begin
ALTER TABLE SiteConfiguration ADD EnableDirectiveImage Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') AND name = 'EnableTemplateFeatureForWorkPermit'
)
begin
ALTER TABLE SiteConfiguration ADD EnableTemplateFeatureForWorkPermit Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') AND name = 'RefreshCSDOnPriorityPage'
)
begin
ALTER TABLE SiteConfiguration ADD RefreshCSDOnPriorityPage Int
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') AND name = 'SetWorkPermitQuestionForMudsSite'
)
begin
ALTER TABLE SiteConfiguration ADD SetWorkPermitQuestionForMudsSite varchar(max)
end
Go






