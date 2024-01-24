CREATE TABLE [dbo].PermitRequestOssa (
	Id bigint IDENTITY(100,1) NOT NULL,
	WorkPermitTypeId int NOT NULL,
	FunctionalLocationId bigint NOT NULL,
	OperationNumber varchar(4) NULL,
	SubOperationNumber varchar(4) null,
	Company varchar(50) null,
	Supervisor varchar(100) null,
	StartDate datetime NOT NULL,
	EndDate datetime NOT NULL,
	WorkOrderNumber varchar(12) NULL,
	Trade varchar(100) NOT NULL,
	Description varchar(400) NOT NULL,
	SapDescription varchar(400) NULL,
	SourceId int NOT NULL,
	IsModified bit NOT NULL,
	LastImportedByUserId bigint null,
	LastImportedDateTime datetime null,
	LastSubmittedByUserId bigint null,
	LastSubmittedDateTime datetime null,
	CreatedByUserId bigint NOT NULL,
	CreatedDateTime datetime NOT NULL,
	LastModifiedByUserId bigint NOT NULL,
	LastModifiedDateTime datetime NOT NULL,
	Deleted bit NOT NULL,
CONSTRAINT PK_PermitRequestOssa PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)
GO

ALTER TABLE PermitRequestOssa
ADD CONSTRAINT FK_PermitRequestOssa_FunctionalLocation FOREIGN KEY(FunctionalLocationId)
REFERENCES FunctionalLocation (Id)
GO

ALTER TABLE PermitRequestOssa
ADD CONSTRAINT FK_PermitRequestOssa_CreatedByUser FOREIGN KEY(CreatedByUserId)
REFERENCES [User] (Id)
GO

ALTER TABLE PermitRequestOssa
ADD CONSTRAINT FK_PermitRequestOssa_LastModifiedByUser FOREIGN KEY(LastModifiedByUserId)
REFERENCES [User] (Id)
GO


CREATE NONCLUSTERED INDEX [IDX_PermitRequestOssa] ON [dbo].[PermitRequestOssa] 
(
	[FunctionalLocationId] ASC,
	[StartDate] ASC,
	[EndDate] ASC,
	[Deleted] ASC
);

GO

alter table PermitRequestOssa
ADD  CONSTRAINT FK_PermitRequestOssa_LastImportedByUser
FOREIGN KEY(LastImportedByUserId)
REFERENCES [User] ([Id]);

alter table PermitRequestOssa
ADD  CONSTRAINT FK_PermitRequestOssa_LastSubmittedByUser
FOREIGN KEY(LastSubmittedByUserId)
REFERENCES [User] ([Id]);

-- -------------------------
CREATE TABLE [dbo].PermitRequestOssaPermitAttributeAssociation (
	PermitRequestOssaId bigint not null,
	PermitAttributeId bigint not null
)
ON [PRIMARY];
GO


ALTER TABLE [dbo].PermitRequestOssaPermitAttributeAssociation
ADD CONSTRAINT [FK_PermitRequestOssaPermitAttributeAssociation_PermitRequestOssa] 
FOREIGN KEY(PermitRequestOssaId)
REFERENCES [dbo].PermitRequestOssa ([Id])

go

ALTER TABLE [dbo].PermitRequestOssaPermitAttributeAssociation
ADD CONSTRAINT [FK_PermitRequestOssaPermitAttributeAssociation_PermitAttribute] 
FOREIGN KEY(PermitAttributeId)
REFERENCES [dbo].PermitAttribute ([Id])


GO

