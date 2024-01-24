
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGenericTemplate]') 
         AND name = 'PlantID'
)
begin
alter table [dbo].[FormGenericTemplate] Add PlantID bigint 
end
Go


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGenericTemplate]') 
         AND name = 'CreatedByRoleId'
)
begin
alter table [dbo].[FormGenericTemplate] Add CreatedByRoleId bigint 
end
Go

