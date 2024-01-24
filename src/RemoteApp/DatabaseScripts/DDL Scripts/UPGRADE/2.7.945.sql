alter table [Log]
add LogType tinyint null
go

update [Log]
set LogType = 1
go

alter table [Log]
alter column LogType tinyint not null
go

GO
