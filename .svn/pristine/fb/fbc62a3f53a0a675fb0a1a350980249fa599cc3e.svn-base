-- ActionItemDefinition --

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinition]') 
         AND name = 'GN75BId1'
)
begin
alter table [dbo].[ActionItemDefinition] Add GN75BId1 bigint SPARSE
end
Go

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinition]') 
         AND name = 'GN75BId2'
)
begin
alter table [dbo].[ActionItemDefinition] Add GN75BId2 bigint SPARSE
end
Go


-- ActionItemDefinitionHistory --

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionHistory]') 
         AND name = 'GN75BId1'
)
begin
alter table [dbo].[ActionItemDefinitionHistory] Add GN75BId1 bigint SPARSE
end
Go

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionHistory]') 
         AND name = 'GN75BId2'
)
begin
alter table [dbo].[ActionItemDefinitionHistory] Add GN75BId2 bigint SPARSE
end
Go



-- ActionItem --

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItem]') 
         AND name like '%GN75BId1'
)
begin
alter table [dbo].[ActionItem] Add FormGN75BId1 bigint SPARSE
end
Go

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItem]') 
         AND name like '%GN75BId2'
)
begin
alter table [dbo].[ActionItem] Add FormGN75BId2 bigint SPARSE
end
Go








