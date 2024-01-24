-- add summary and recommend for shift summary columns to log history
alter table [LogHistory]
add Summary varchar(100) null

alter table [LogHistory]
add RecommendForShiftSummary bit null

go

update [LogHistory]
set Summary = ''

update [LogHistory]
set RecommendForShiftSummary = 0

go

alter table [LogHistory]
alter column Summary varchar(100) not null

alter table [LogHistory]
alter column RecommendForShiftSummary bit not null

go

-- add summary to log definition history

alter table [LogDefinitionHistory]
add Summary varchar(100) null

go

update [LogDefinitionHistory]
set Summary = ''

go

alter table [LogDefinitionHistory]
alter column Summary varchar(100) not null

go


GO
