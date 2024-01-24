CREATE TABLE [dbo].PermitRequestEdmonton (
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
CONSTRAINT PK_PermitRequestEdmonton PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)
GO

ALTER TABLE PermitRequestEdmonton
ADD CONSTRAINT FK_PermitRequestEdmonton_FunctionalLocation FOREIGN KEY(FunctionalLocationId)
REFERENCES FunctionalLocation (Id)
GO

ALTER TABLE PermitRequestEdmonton
ADD CONSTRAINT FK_PermitRequestEdmonton_CreatedByUser FOREIGN KEY(CreatedByUserId)
REFERENCES [User] (Id)
GO

ALTER TABLE PermitRequestEdmonton
ADD CONSTRAINT FK_PermitRequestEdmonton_LastModifiedByUser FOREIGN KEY(LastModifiedByUserId)
REFERENCES [User] (Id)
GO


CREATE NONCLUSTERED INDEX [IDX_PermitRequestEdmonton] ON [dbo].[PermitRequestEdmonton] 
(
	[FunctionalLocationId] ASC,
	[StartDate] ASC,
	[EndDate] ASC,
	[Deleted] ASC
);

GO

alter table PermitRequestEdmonton
ADD  CONSTRAINT FK_PermitRequestEdmonton_LastImportedByUser
FOREIGN KEY(LastImportedByUserId)
REFERENCES [User] ([Id]);

alter table PermitRequestEdmonton
ADD  CONSTRAINT FK_PermitRequestEdmonton_LastSubmittedByUser
FOREIGN KEY(LastSubmittedByUserId)
REFERENCES [User] ([Id]);

-- -------------------------

CREATE TABLE [dbo].PermitRequestEdmontonPermitAttributeAssociation (
	PermitRequestEdmontonId bigint not null,
	PermitAttributeId bigint not null
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].PermitRequestEdmontonPermitAttributeAssociation
ADD CONSTRAINT [FK_PermitRequestEdmontonPermitAttributeAssociation_PermitRequestEdmonton] 
FOREIGN KEY(PermitRequestEdmontonId)
REFERENCES [dbo].PermitRequestEdmonton ([Id])

GO

ALTER TABLE [dbo].PermitRequestEdmontonPermitAttributeAssociation
ADD CONSTRAINT [FK_PermitRequestEdmontonPermitAttributeAssociation_PermitAttribute] 
FOREIGN KEY(PermitAttributeId)
REFERENCES [dbo].PermitAttribute ([Id])


GO




GO

