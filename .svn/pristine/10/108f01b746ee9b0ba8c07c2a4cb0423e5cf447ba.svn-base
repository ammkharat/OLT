-- add summary column to log definition table

alter table [LogDefinition]
add Summary varchar(100) null
go

update LogDefinition
set Summary = ''

go

alter table LogDefinition
alter column Summary  varchar(100) not null

go







GO
