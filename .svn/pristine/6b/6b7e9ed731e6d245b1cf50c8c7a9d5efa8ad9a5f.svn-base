IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[RestrictionDefinition]') 
         AND name = 'ToleranceValue'
)
Begin
ALTER TABLE RestrictionDefinition ADD ToleranceValue int

End


--DMND0010124 mangesh
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[RestrictionDefinition]') 
         AND name = 'HourFrequency'
)
Begin
ALTER TABLE RestrictionDefinition ADD HourFrequency bigint
End

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[RestrictionDefinitionHistory]') 
         AND name = 'HourFrequency'
)
Begin
ALTER TABLE RestrictionDefinitionHistory ADD HourFrequency bigint
End

