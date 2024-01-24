alter table SummaryLog add CreatedDateTime datetime null;

GO

update SummaryLog set CreatedDateTime = LoggedDate;

GO

alter table SummaryLog alter column CreatedDateTime datetime not null;

GO

exec sp_RENAME 'SummaryLog.LoggedDate', 'LogDateTime', 'COLUMN'

GO
GO
