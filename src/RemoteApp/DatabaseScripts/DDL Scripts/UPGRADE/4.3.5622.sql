

alter table dbo.WorkPermitOssa alter column Company varchar(50) NULL
go

alter table dbo.WorkPermitOssa
add OperationNumber varchar(4) NULL,
    SubOperationNumber varchar(4) NULL
go

alter table dbo.WorkPermitOssaHistory
add OperationNumber varchar(4) NULL,
    SubOperationNumber varchar(4) NULL
go




GO

