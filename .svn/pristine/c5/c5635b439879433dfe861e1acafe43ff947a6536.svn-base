--Alter actionitem and actionitemdefinition tables to add visibilitygroupids column
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Actionitem]') 
         AND name = 'visibilitygroupids'
)
begin
alter table [dbo].[Actionitem] Add [visibilitygroupids] varchar(100)
end
Go

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionitemDefinition]') 
         AND name = 'visibilitygroupids'
)
begin
alter table [dbo].[ActionitemDefinition] Add [visibilitygroupids] varchar(100)
end
Go












GO

