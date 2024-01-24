alter table [Log] add Comments varchar(max) null;
alter table [LogDefinition] add Comments varchar(max) null;

GO

update [Log] set Comments = AllComments;
update [LogDefinition] set Comments = AllComments;

GO

exec sp_RENAME 'Log.AllComments', 'CommentsAsPlainText', 'COLUMN'
exec sp_RENAME 'LogDefinition.AllComments', 'CommentsAsPlainText', 'COLUMN'

GO

alter table [Log] alter column Comments varchar(max) not null;
alter table [LogDefinition] alter column Comments varchar(max) not null;

GO
