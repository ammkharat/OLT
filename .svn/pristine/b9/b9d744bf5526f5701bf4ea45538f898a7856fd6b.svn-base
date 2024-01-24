---Added EnableWorkPermitSignature Column

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'EnableWorkPermitSignature'
)
BEGIN
ALTER TABLE SiteConfiguration ADD EnableWorkPermitSignature bit  default(0) 
END