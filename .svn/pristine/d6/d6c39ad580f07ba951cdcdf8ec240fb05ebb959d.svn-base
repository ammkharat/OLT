
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Schedule]') 
         AND name = 'EveryShift'
)
BEGIN
ALTER TABLE Schedule ADD EveryShift [bit] NULL
END