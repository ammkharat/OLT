
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'FormGN75BTemplateId'
)
begin
alter table [dbo].[DocumentLink] Add FormGN75BTemplateId bigint NULL 
end
Go

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'Title'
)
begin
ALTER TABLE DocumentLink ALTER COLUMN Title varchar(100)
end
Go

