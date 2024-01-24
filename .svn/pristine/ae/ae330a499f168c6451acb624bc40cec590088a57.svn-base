alter table ActionItemDefinition
add CreateAnActionItemForEachFunctionalLocation bit null;

go

update ActionItemDefinition
set CreateAnActionItemForEachFunctionalLocation = 1

go

alter table ActionItemDefinition
alter column CreateAnActionItemForEachFunctionalLocation bit not null;

go

GO
