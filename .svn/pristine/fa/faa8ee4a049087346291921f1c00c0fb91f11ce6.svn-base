alter table LogTemplate add AppliesToLogs bit NULL;
alter table LogTemplate add AppliesToSummaryLogs bit NULL;

GO

update LogTemplate set AppliesToLogs = 1;
update LogTemplate set AppliesToSummaryLogs = 0;

GO

alter table LogTemplate alter column AppliesToLogs bit NOT NULL;
alter table LogTemplate alter column AppliesToSummaryLogs bit NOT NULL;

GO




GO

