

alter table dbo.WorkPermitEdmonton add [Group] varchar(50) null;
go

update dbo.WorkPermitEdmonton set [Group] = 'testomatic';   --- this feature isn't released so it's ok to put some junk in any existing ones
go

alter table dbo.WorkPermitEdmonton alter column [Group] varchar(50) not null;
go





GO

