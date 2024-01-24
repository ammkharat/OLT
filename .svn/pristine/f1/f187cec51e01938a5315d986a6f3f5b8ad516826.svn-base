IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormOP14]') 
         AND name = 'IsSCADAsupportRequired'
)
begin
ALTER TABLE dbo.FormOP14 Add IsSCADAsupportRequired bit
end

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormOP14History]') 
         AND name = 'IsSCADAsupportRequired'
)
begin
ALTER TABLE dbo.FormOP14History Add IsSCADAsupportRequired bit
end



GO

