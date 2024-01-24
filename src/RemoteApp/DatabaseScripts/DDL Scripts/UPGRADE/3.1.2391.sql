alter table ActionItemDefinitionAutoReApprovalConfiguration
add ActionItemGenerationModeChange bit null;

go

update ActionItemDefinitionAutoReApprovalConfiguration
set ActionItemGenerationModeChange = 1

go

alter table ActionItemDefinitionAutoReApprovalConfiguration
alter column ActionItemGenerationModeChange bit not null;

go

GO

GO
