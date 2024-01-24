CREATE TABLE [dbo].[PermitRequestOssaHistory](
	Id bigint NOT NULL,
	WorkPermitTypeId int NOT NULL,
	FunctionalLocationId bigint NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NOT NULL,
	WorkOrderNumber varchar(12) NULL,
	Trade varchar(100) NOT NULL,
	Description varchar(400) NOT NULL,
	SapDescription varchar(400) null,
	LastModifiedByUserId bigint NOT NULL,
	LastModifiedDateTime datetime NOT NULL,
	OperationNumber varchar(4) null,
	Company varchar(50) null,
	Supervisor varchar(100) null,
	LastImportedByUserId bigint null,
	LastImportedDateTime datetime null,
	LastSubmittedByUserId bigint null,
	LastSubmittedDateTime datetime null,
	Attributes varchar(max) null
) ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [IDX_PermitRequestOssaHistory] ON [dbo].[PermitRequestOssaHistory]
(
	[Id] ASC
)

GO



GO

