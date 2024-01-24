IF not EXISTS (select 1 from formgn24 where siteid = 8)
begin
update FormGN24 set siteid = 8 where siteid is null
end
go
IF not EXISTS (select 1 from formgn1 where siteid = 8)
begin
update FormGN1 set siteid = 8 where siteid is null
end 
go
IF not EXISTS (select 1 from formgn59 where siteid = 8)
begin
update FormGN59 set siteid = 8 where siteid is null
end 
go
IF not EXISTS (select 1 from formgn6 where siteid = 8)
begin
update FormGN6 set siteid = 8 where siteid is null
end
go
IF not EXISTS (select 1 from formgn7 where siteid = 8)
begin
update FormGN7 set siteid = 8 where siteid is null
end
go
IF not EXISTS (select 1 from formgn75a where siteid = 8)
begin
update FormGN75A set siteid = 8 where siteid is null
end
go

IF not EXISTS (select 1 from formgn75b where siteid = 8)
begin
update FormGN75B set siteid = 8 where siteid is null
end
go
IF not EXISTS (select 1 from formTemplate where siteid = 8)
begin
update FormTemplate set siteid = 8 where siteid is null
end 
go

IF not EXISTS (select 1 from formop14 where siteid = 8)
begin
update Formop14 set siteid = 8 where siteid is null
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
if not exists (select 1 from overtimeform where siteid = 8)
begin
update overtimeform set siteid = 8 where siteid is null
end
GO

