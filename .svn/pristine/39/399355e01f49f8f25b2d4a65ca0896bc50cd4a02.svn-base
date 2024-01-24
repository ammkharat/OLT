CREATE TABLE [dbo].WorkPermitOssaPermitAttributeAssociation (
	WorkPermitOssaId bigint not null,
	PermitAttributeId bigint not null
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].WorkPermitOssaPermitAttributeAssociation
ADD CONSTRAINT [FK_WorkPermitOssaPermitAttributeAssociation_WorkPermitOssa] 
FOREIGN KEY(WorkPermitOssaId)
REFERENCES [dbo].WorkPermitOssa ([Id])

go


ALTER TABLE [dbo].WorkPermitOssaPermitAttributeAssociation
ADD CONSTRAINT [FK_WorkPermitOssaPermitAttributeAssociation_PermitAttribute] 
FOREIGN KEY(PermitAttributeId)
REFERENCES [dbo].PermitAttribute ([Id])

go

CREATE NONCLUSTERED INDEX [IDX_WorkPermitOssaPermitAttributeAssociation]
ON [dbo].[WorkPermitOssaPermitAttributeAssociation]
([WorkPermitOssaId])
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

CREATE NONCLUSTERED INDEX [IDX_PermitRequestOssaPermitAttributeAssociation]
ON [dbo].[PermitRequestOssaPermitAttributeAssociation]
([PermitRequestOssaId])
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




GO

CREATE TABLE [dbo].[WorkPermitOssaRequestDetails] (
	[Id] bigint NOT NULL,
	RequestedDateTime datetime null,
	RequestedByUserId bigint null,
	Supervisor varchar(100) null
CONSTRAINT [PK_WorkPermitOssaRequestDetails]
PRIMARY KEY CLUSTERED ([Id] ) ON [PRIMARY]
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[WorkPermitOssaRequestDetails]
ADD  CONSTRAINT [FK_WorkPermitOssaRequestDetails_Id]
FOREIGN KEY ([Id])
REFERENCES [dbo].[WorkPermitOssa] ( [Id] )
GO

alter table WorkPermitOssaRequestDetails
ADD  CONSTRAINT FK_WorkPermitOssaRequestDetails_RequestedByUser
FOREIGN KEY(RequestedByUserId)
REFERENCES [User] ([Id]);

go




GO

