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




GO

