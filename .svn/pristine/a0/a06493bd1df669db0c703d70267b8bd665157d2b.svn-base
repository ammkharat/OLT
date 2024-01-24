IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[TrainingBlock]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[TrainingBlock] add [siteid] [bigint] NULL
end
go

if exists (select * from TrainingBlock where siteid is null)
begin
update TrainingBlock set [siteid] = 3 where siteid is null
end




