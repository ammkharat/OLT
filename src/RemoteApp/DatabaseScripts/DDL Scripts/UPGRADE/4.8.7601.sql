alter table SummaryLog add DataSourceId int null;
GO

update SummaryLog set DataSourceId = 0;
GO

alter table SummaryLog alter column DataSourceId int not null;



GO

