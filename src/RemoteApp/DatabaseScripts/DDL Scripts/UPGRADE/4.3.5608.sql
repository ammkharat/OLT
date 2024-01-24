

alter table dbo.WorkPermitOssa add Location varchar(100) null;
alter table dbo.WorkPermitOssaHistory add Location varchar(100) null;
go


--- we are not in prod yet, so I'm just going to set these to anything I like

update dbo.WorkPermitOssa set Location = 'location';
update dbo.WorkPermitOssaHistory set Location = 'location';
go

alter table dbo.WorkPermitOssa alter column Location varchar(100) not null;
alter table dbo.WorkPermitOssaHistory alter column Location varchar(100) not null;
go





GO

