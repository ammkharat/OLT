

alter table dbo.PermitRequestEdmonton add CompletionStatusId int null
go

update dbo.PermitRequestEdmonton set CompletionStatusId = 1 where IsComplete = 1
update dbo.PermitRequestEdmonton set CompletionStatusId = 0 where IsComplete = 0
go

alter table dbo.PermitRequestEdmonton alter column CompletionStatusId int not null;
go

DROP INDEX [IDX_PermitRequestEdmonton_Covering_Others] ON [dbo].[PermitRequestEdmonton];
go

CREATE NONCLUSTERED INDEX [IDX_PermitRequestEdmonton_Covering_Others]
ON [dbo].[PermitRequestEdmonton]
([RequestedStartDate] , [EndDate] , [Deleted])
INCLUDE ([CompletionStatusId], [GroupId], [DataSourceId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

alter table dbo.PermitRequestEdmonton drop column IsComplete;
go








alter table dbo.PermitRequestEdmontonHistory add CompletionStatusId int null
go

update dbo.PermitRequestEdmontonHistory set CompletionStatusId = 1 where IsComplete = 1
update dbo.PermitRequestEdmontonHistory set CompletionStatusId = 0 where IsComplete = 0
go

alter table dbo.PermitRequestEdmontonHistory alter column CompletionStatusId int not null;
go

alter table dbo.PermitRequestEdmontonHistory drop column IsComplete;
go


















GO

