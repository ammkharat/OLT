
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemResponseTracker]') 
         AND name = 'ActionItemDefinitionId'
)
BEGIN
ALTER TABLE ActionItemResponseTracker ADD ActionItemDefinitionId [bigint] NULL
END