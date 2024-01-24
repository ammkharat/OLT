IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DeviationAlert]') 
         AND name = 'ToleranceValue'
)
begin
ALTER TABLE dbo.DeviationAlert Add ToleranceValue int
end


GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[RestrictionDefinition]') 
         AND name = 'ToleranceValue'
)
Begin
ALTER TABLE RestrictionDefinition ADD ToleranceValue int

End


GO


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[RestrictionDefinitionHistory]') 
         AND name = 'ToleranceValue'
)
Begin
ALTER  TABLE dbo.RestrictionDefinitionHistory ADD ToleranceValue int
End


GO

