-- 1. Add a Created column and copy the LoggedDate into it.
alter table [Log] add CreatedDateTime datetime null;

GO

update [Log] set CreatedDateTime = LoggedDate;

GO

alter table [Log] alter column CreatedDateTime datetime not null;

GO

-- 2. Copy out old "actual" values and remove the column
update [Log] set LoggedDate = ActualLoggedDateTime where ActualLoggedDateTime is not null;

GO

alter table [Log] drop column ActualLoggedDateTime;

GO

-- Rename the LoggedDate column to make sense
exec sp_RENAME 'Log.LoggedDate', 'LogDateTime', 'COLUMN'

GO

-- Rename it in LogDefinition too just to be complete
exec sp_RENAME 'LogDefinition.LoggedDate', 'LogDateTime', 'COLUMN'
GO
