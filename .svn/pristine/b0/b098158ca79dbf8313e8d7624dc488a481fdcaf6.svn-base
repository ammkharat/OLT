
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[CustomFieldGroup]') 
         AND name = 'AppliesToActionItems'
)
begin
ALTER TABLE dbo.CustomFieldGroup ADD AppliesToActionItems BIT NOT NULL DEFAULT(0)
end

