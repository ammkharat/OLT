

alter table dbo.PermitRequestMontreal add CompletionStatusId int null
alter table dbo.PermitRequestMontrealHistory add CompletionStatusId int null
go

update dbo.PermitRequestMontreal set CompletionStatusId = 2  -- incomplete
update dbo.PermitRequestMontrealHistory set CompletionStatusId = 2   -- incomplete
go

alter table dbo.PermitRequestMontreal alter column CompletionStatusId int not null;
alter table dbo.PermitRequestMontrealHistory alter column CompletionStatusId int not null;
go


GO

