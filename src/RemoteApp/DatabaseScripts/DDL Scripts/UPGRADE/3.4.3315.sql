alter table SummaryLogCustomField
alter column Name varchar(40) not null;

alter table SummaryLogCustomFieldEntry
alter column SummaryLogCustomFieldName varchar(40) not null;

alter table SummaryLogCustomFieldEntryHistory
alter column SummaryLogCustomFieldName varchar(40) not null;

go
;
GO
