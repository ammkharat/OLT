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



GO

