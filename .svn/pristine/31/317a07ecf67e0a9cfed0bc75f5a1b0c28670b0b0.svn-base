IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DeviationAlert]') 
         AND name = 'ToleranceValue'
)
begin
ALTER TABLE dbo.DeviationAlert Add ToleranceValue int
end