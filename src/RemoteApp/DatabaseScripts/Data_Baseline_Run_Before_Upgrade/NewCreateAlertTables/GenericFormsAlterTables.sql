IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[formgn24]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formgn24] add [siteid] [bigint] NULL
end
go

IF not EXISTS (SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[formgn1]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN1] add [siteid] [bigint] NULL
end 
go

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[formgn59]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN59] add [siteid] [bigint] NULL
end 
go

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN6]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN6] add [siteid] [bigint] NULL
end
go


IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN7]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN7] add [siteid] [bigint] NULL
end
go

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75A]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN75A] add [siteid] bigint NULL
end
go

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75B]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN75B] add [siteid] [bigint] NULL
end
go

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Formop14]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formop14] add [siteid] [bigint] NULL
end 
go
IF not EXISTS (select 1 from formop14 where siteid = 8)
begin
update FormOP14 set siteid = 8 where siteid is null
end 
go
IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormTemplate]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formtemplate] add [siteid] [bigint] NULL
end 
go

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[OvertimeForm]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[OvertimeForm] add [siteid] [bigint] NULL
end 
go
IF not EXISTS (select 1 from OvertimeForm where siteid = 8)
begin
update OvertimeForm set siteid = 8 where siteid is null
end 
go

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormOilsandsTraining]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormOilsandsTraining] add [siteid] [bigint] NULL
end 
go
IF not EXISTS (select 1 from FormOilsandsTraining where siteid = 3)
begin
update FormOilsandsTraining set siteid = 3 where siteid is null
end 
go
