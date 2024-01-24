alter table LogDefinition
add CreateALogForEachFunctionalLocation bit null;

go

update LogDefinition
set CreateALogForEachFunctionalLocation = 1;

go

alter table LogDefinition
alter column CreateALogForEachFunctionalLocation bit not null;

go



GO
