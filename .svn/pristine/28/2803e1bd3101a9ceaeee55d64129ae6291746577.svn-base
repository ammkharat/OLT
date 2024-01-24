SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[FormDocumentSuggestion] (
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
[LocationEquipmentNumber] varchar(100) NULL,
[ScheduledCompletionDateTime] datetime NULL,
[NumberOfExtensions] int NOT NULL default(0),
[IsExistingDocument] bit NOT NULL,
[DocumentOwner] varchar(100) NULL,
[DocumentNumber] varchar(100) NULL,
[DocumentTitle] varchar(255) NULL,
[OriginalMarkedUp] bit NOT NULL,
[HardCopySubmittedTo] varchar(100) NULL,
[RecommendedToBeArchived] bit NOT NULL,
[Description] varchar(MAX) NULL,
[InitialReviewApprovedBy] varchar(100) NULL,
[InitialReviewApprovedDateTime] datetime NULL,
[OwnerReviewApprovedBy] varchar(100) NULL,
[OwnerReviewApprovedDateTime] datetime NULL,
[RevisionInProgressApprovedBy] varchar(100) NULL,
[RevisionInProgressApprovedDateTime] datetime NULL,
[DocumentIssuedApprovedBy] varchar(100) NULL,
[DocumentIssuedApprovedDateTime] datetime NULL,
[NotApprovedBy] varchar(100) NULL,
[NotApprovedDateTime] datetime NULL,
CONSTRAINT [PK_FormDocumentSuggestion]
PRIMARY KEY CLUSTERED ([Id] ASC),
CONSTRAINT [FK_FormDocumentSuggestion_CreatedByUser]
FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ( [Id] ),
CONSTRAINT [FK_FormDocumentSuggestion_LastModifiedUser]
FOREIGN KEY ([LastModifiedByUserId])
REFERENCES [dbo].[User] ( [Id] ),
CONSTRAINT [FK_FormDocumentSuggestion_SiteId]
FOREIGN KEY ([SiteId])
REFERENCES [dbo].[Site] ( [Id] )
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[FormDocumentSuggestion] SET (LOCK_ESCALATION = TABLE);
GO

CREATE TABLE [dbo].[FormDocumentSuggestionHistory] (
[DocumentSuggestionHistoryId] bigint IDENTITY(100, 1) NOT FOR REPLICATION NOT NULL,
[Id] bigint NOT NULL,
[FormStatusId] int NOT NULL,
[FunctionalLocations] varchar(MAX) NOT NULL,
[DocumentLinks] varchar(MAX) NULL,
[ValidFromDateTime] datetime NOT NULL,
[ValidToDateTime] datetime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[LocationEquipmentNumber] varchar(100) NULL,
[ScheduledCompletionDateTime] datetime NULL,
[NumberOfExtensions] int NOT NULL default(0),
[IsExistingDocument] bit NOT NULL,
[DocumentOwner] varchar(100) NULL,
[DocumentNumber] varchar(100) NULL,
[DocumentTitle] varchar(255) NULL,
[OriginalMarkedUp] bit NOT NULL,
[HardCopySubmittedTo] varchar(100) NULL,
[RecommendedToBeArchived] bit NOT NULL,
[Description] varchar(MAX) NULL,
[InitialReviewApprovedBy] varchar(100) NULL,
[InitialReviewApprovedDateTime] datetime NULL,
[OwnerReviewApprovedBy] varchar(100) NULL,
[OwnerReviewApprovedDateTime] datetime NULL,
[RevisionInProgressApprovedBy] varchar(100) NULL,
[RevisionInProgressApprovedDateTime] datetime NULL,
[DocumentIssuedApprovedBy] varchar(100) NULL,
[DocumentIssuedApprovedDateTime] datetime NULL,
[NotApprovedBy] varchar(100) NULL,
[NotApprovedDateTime] datetime NULL
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[FormDocumentSuggestionHistory] SET (LOCK_ESCALATION = TABLE);
GO

CREATE TABLE [dbo].[FormDocumentSuggestionFunctionalLocation] (
[FormDocumentSuggestionId] bigint NOT NULL,
[FunctionalLocationId] bigint NOT NULL,
CONSTRAINT [FK_FormDocumentSuggestionFunctionalLocation_FormDocumentSuggestion]
FOREIGN KEY ([FormDocumentSuggestionId])
REFERENCES [dbo].[FormDocumentSuggestion] ( [Id] ),
CONSTRAINT [FK_FormDocumentSuggestionFunctionalLocation_FunctionalLocation]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] )
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[FormDocumentSuggestionFunctionalLocation] SET (LOCK_ESCALATION = TABLE);
GO

CREATE TABLE [dbo].[FormDocumentSuggestionComment] (
[FormDocumentSuggestionId] bigint NOT NULL,
[CommentId] bigint NOT NULL,
CONSTRAINT [FK_FormDocumentSuggestionComment_FormDocumentSuggestion]
FOREIGN KEY ([FormDocumentSuggestionId])
REFERENCES [dbo].[FormDocumentSuggestion] ( [Id] ),
CONSTRAINT [FK_FormDocumentSuggestion_Comment]
FOREIGN KEY ([CommentId])
REFERENCES [dbo].[Comment] ( [Id] )
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[FormDocumentSuggestionComment] SET (LOCK_ESCALATION = TABLE);
GO






GO

