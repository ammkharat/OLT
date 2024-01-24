
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'FormGN75BSarniaId'
)
BEGIN
ALTER TABLE DocumentLink ADD FormGN75BSarniaId bigint NULL
END