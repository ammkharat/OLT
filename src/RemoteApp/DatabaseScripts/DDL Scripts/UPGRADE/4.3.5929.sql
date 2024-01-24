
alter table dbo.CustomField add TypeId int null;
go

update dbo.CustomField set TypeId = 0;
go

alter table dbo.CustomField alter column TypeId int not null;
go



GO

