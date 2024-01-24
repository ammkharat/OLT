SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[FormProcedureDeviation] (
[Id] bigint NOT NULL,
[FormStatusId] int NOT NULL,
[ValidFromDateTime] datetime NOT NULL,
[ValidToDateTime] datetime NOT NULL,
[ApprovedDateTime] datetime NULL,
[CreatedByUserId] bigint NOT NULL,
[CreatedDateTime] datetime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[Deleted] bit NOT NULL,
[SiteId] bigint NOT NULL,
[DeviationType] int NOT NULL,
[PermanentRevisionRequired] bit NOT NULL,
[RevertedBackToOriginal] bit NOT NULL,
[LocationEquipmentNumber] varchar(100) NULL,
[NumberOfExtensions] int NOT NULL default(0),
[OperatingProcedureNumber] varchar(100) NULL,
[OperatingProcedureTitle] varchar(255) NULL,
[OperatingProcedureLevel] int NOT NULL,
[Description] varchar(MAX) NULL,
[RichTextDescription] varchar(MAX) NULL,
[WhyType1] int NOT NULL,
[WhyType1Category] varchar(100) NULL,
[CauseDeterminationWhy1Comments] varchar(255) NULL,
[CauseDeterminationWhy2Comments] varchar(255) NULL,
[CauseDeterminationWhy3Comments] varchar(255) NULL,
[FixDocumentDurationType] int NOT NULL,
[CorrectiveActionIlpNumber] varchar(100) NULL,
[CorrectiveActionWorkRequestNumber] varchar(100) NULL,
[CorrectiveActionOtherComments] varchar(255) NULL,
[AffectsToe] bit NOT NULL,
[CancelledBy] varchar(100) NULL,
[CancelledDateTime] datetime NULL,
[CancelledReason] varchar(255) NULL,
CONSTRAINT [PK_FormProcedureDeviation]
PRIMARY KEY CLUSTERED ([Id] ASC),
CONSTRAINT [FK_FormProcedureDeviation_CreatedByUser]
FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ( [Id] ),
CONSTRAINT [FK_FormProcedureDeviation_LastModifiedUser]
FOREIGN KEY ([LastModifiedByUserId])
REFERENCES [dbo].[User] ( [Id] ),
CONSTRAINT [FK_FormProcedureDeviation_SiteId]
FOREIGN KEY ([SiteId])
REFERENCES [dbo].[Site] ( [Id] )
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[FormProcedureDeviation] SET (LOCK_ESCALATION = TABLE);
GO

CREATE TABLE [dbo].[FormProcedureDeviationHistory] (
[ProcedureDeviationHistoryId] bigint IDENTITY(100, 1) NOT FOR REPLICATION NOT NULL,
[Id] bigint NOT NULL,
[FormStatusId] int NOT NULL,
[FunctionalLocations] varchar(MAX) NOT NULL,
[DocumentLinks] varchar(MAX) NULL,
[ValidFromDateTime] datetime NOT NULL,
[ValidToDateTime] datetime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[DeviationType] int NOT NULL,
[PermanentRevisionRequired] bit NOT NULL,
[RevertedBackToOriginal] bit NOT NULL,
[LocationEquipmentNumber] varchar(100) NULL,
[NumberOfExtensions] int NOT NULL default(0),
[ReasonsForExtension] varchar(MAX) NULL,
[OperatingProcedureNumber] varchar(100) NULL,
[OperatingProcedureTitle] varchar(255) NULL,
[OperatingProcedureLevel] int NOT NULL,
[Description] varchar(MAX) NULL,
[WhyType1] int NOT NULL,
[WhyType1Category] varchar(100) NULL,
[CauseDeterminationWhy1Comments] varchar(255) NULL,
[CauseDeterminationWhy2Comments] varchar(255) NULL,
[CauseDeterminationWhy3Comments] varchar(255) NULL,
[FixDocumentDurationType] int NOT NULL,
[CorrectiveActionIlpNumber] varchar(100) NULL,
[CorrectiveActionWorkRequestNumber] varchar(100) NULL,
[CorrectiveActionOtherComments] varchar(255) NULL,
[AffectsToe] bit NOT NULL,
[CancelledBy] varchar(100) NULL,
[CancelledDateTime] datetime NULL,
[CancelledReason] varchar(255) NULL
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] SET (LOCK_ESCALATION = TABLE);
GO

CREATE TABLE [dbo].[FormProcedureDeviationFunctionalLocation] (
[FormProcedureDeviationId] bigint NOT NULL,
[FunctionalLocationId] bigint NOT NULL,
CONSTRAINT [FK_FormProcedureDeviationFunctionalLocation_FormProcedureDeviation]
FOREIGN KEY ([FormProcedureDeviationId])
REFERENCES [dbo].[FormProcedureDeviation] ( [Id] ),
CONSTRAINT [FK_FormProcedureDeviationFunctionalLocation_FunctionalLocation]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] ),
CONSTRAINT [PK_FormProcedureDeviaionFunctionalLocation]
PRIMARY KEY CLUSTERED ([FormProcedureDeviationId] ASC, [FunctionalLocationId] ASC)
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[FormProcedureDeviationFunctionalLocation] SET (LOCK_ESCALATION = TABLE);
GO

CREATE TABLE [dbo].[FormProcedureDeviationComment] (
[FormProcedureDeviationId] bigint NOT NULL,
[CommentId] bigint NOT NULL,
CONSTRAINT [FK_FormProcedureDeviationComment_FormProcedureDeviation]
FOREIGN KEY ([FormProcedureDeviationId])
REFERENCES [dbo].[FormProcedureDeviation] ( [Id] ),
CONSTRAINT [FK_FormProcedureDeviation_Comment]
FOREIGN KEY ([CommentId])
REFERENCES [dbo].[Comment] ( [Id] ),
CONSTRAINT [PK_FormProcedureDeviationComment]
PRIMARY KEY CLUSTERED ([FormProcedureDeviationId] ASC, [CommentId] ASC)
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[FormProcedureDeviationComment] SET (LOCK_ESCALATION = TABLE);
GO

ALTER TABLE [dbo].[DocumentLink] ADD [FormProcedureDeviationId] bigint NULL
GO

ALTER TABLE [dbo].[DocumentLink] ADD CONSTRAINT [FK_DocumentLink_FormProcedureDeviation]
FOREIGN KEY ([FormProcedureDeviationId]) REFERENCES [dbo].[FormProcedureDeviation] ([Id])
GO





GO

-- Create new RoleElement "View Priorities - Procedure Deviation"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (280, 'View Priorities - Procedure Deviation', 'Forms')
GO

-- Create new RoleElement "Create Form - Procedure Deviation"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (281, 'Create Form - Procedure Deviation', 'Forms')
GO

-- Create new RoleElement "Edit Form - Procedure Deviation"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (282, 'Edit Form - Procedure Deviation', 'Forms')
GO

-- Create new RoleElement "Approve Form - Procedure Deviation"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (283, 'Approve Form - Procedure Deviation', 'Forms')
GO

-- Create new RoleElement "Delete Form - Procedure Deviation"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (284, 'Delete Form - Procedure Deviation', 'Forms')
GO

-- Assign role elements to all WoodBuffalo region sites. Sites include: Firebag (SiteId: 5), MacKay (SiteId: 7), Oilsands (SiteId: 3), Pipelines (SELC) (SiteId: 13), Site Wide Services (SiteId: 6), Voyageur (a.k.a. East Tank Farm) (SiteId: 11), Wood Buffalo Labs (SiteId: 12)

-- Assign View Priorities - Procedure Deviation to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  280, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO

-- Assign Create Form - Procedure Deviation to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  281, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO

-- Assign Edit Form - Procedure Deviation to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  282, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO

-- Assign Approve Form - Procedure Deviation to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  283, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO

-- Assign Delete Form - Procedure Deviation to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  284, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO














GO

update role set name = 'Operations Support' where siteid = 1 and name = 'Engineering Support'
update role set name = 'Permit Requester' where siteid = 1 and name = 'Permit Screener'


GO

