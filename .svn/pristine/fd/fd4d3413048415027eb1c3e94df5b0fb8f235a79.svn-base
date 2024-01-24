
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[RestrictionDefinitionHistory]') 
         AND name = 'ToleranceValue'
)
Begin
ALTER  TABLE dbo.RestrictionDefinitionHistory ADD ToleranceValue int
End