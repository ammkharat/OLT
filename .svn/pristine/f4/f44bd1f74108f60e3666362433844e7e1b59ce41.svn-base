alter table SummaryLogCustomFieldGroup add AppliesToLogs bit null;
alter table SummaryLogCustomFieldGroup add AppliesToSummaryLogs bit null;
alter table SummaryLogCustomFieldGroup add AppliesToDailyDirectives bit null;

GO

update SummaryLogCustomFieldGroup 
set 
	AppliesToLogs = 0, 
	AppliesToSummaryLogs = 1,
	AppliesToDailyDirectives = 0;

GO

alter table SummaryLogCustomFieldGroup alter column AppliesToLogs bit not null;
alter table SummaryLogCustomFieldGroup alter column AppliesToSummaryLogs bit not null;
alter table SummaryLogCustomFieldGroup alter column AppliesToDailyDirectives bit not null;


-- exec sp_rename 'SummaryLogCustomFieldGroup',  'CustomFieldGroup'

-- GO

-- exec sp_rename 'SummaryLogCustomField',  'CustomField'

GO

GO
