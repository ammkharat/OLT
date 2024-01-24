-- add summary column to log table

alter table [Log]
add Summary varchar(100) null

go

update [Log]
set Summary = ''

go

alter table [Log]
alter column Summary varchar(100) not null

go


-- add recommend for shift summary to log table

alter table [Log]
add RecommendForShiftSummary bit null

go

update [Log]
set RecommendForShiftSummary = 0

go

alter table [Log]
alter column RecommendForShiftSummary bit not null

go






GO
