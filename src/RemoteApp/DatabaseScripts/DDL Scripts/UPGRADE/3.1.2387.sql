alter table ActionItemDefinitionHistory
add CreateAnActionItemForEachFunctionalLocation bit null;

go

update ActionItemDefinitionHistory
set CreateAnActionItemForEachFunctionalLocation = 1

go

alter table ActionItemDefinitionHistory
alter column CreateAnActionItemForEachFunctionalLocation bit not null;

go

GO
