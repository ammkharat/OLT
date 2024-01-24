SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER TABLE [dbo].[FormDocumentSuggestion] ADD [RichTextDescription] varchar(MAX) NULL
GO
ALTER TABLE [dbo].[FormDocumentSuggestion] ADD [DocumentArchivedApprovedBy] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormDocumentSuggestion] ADD [DocumentArchivedApprovedDateTime] datetime NULL
GO
ALTER TABLE [dbo].[FormDocumentSuggestionHistory] ADD [DocumentArchivedApprovedBy] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormDocumentSuggestionHistory] ADD [DocumentArchivedApprovedDateTime] datetime NULL
GO
ALTER TABLE [dbo].[FormDocumentSuggestion] DROP COLUMN [RevisionInProgressApprovedBy]
GO
ALTER TABLE [dbo].[FormDocumentSuggestion] DROP COLUMN [RevisionInProgressApprovedDateTime]
GO
ALTER TABLE [dbo].[FormDocumentSuggestionHistory] DROP COLUMN [RevisionInProgressApprovedBy]
GO
ALTER TABLE [dbo].[FormDocumentSuggestionHistory] DROP COLUMN [RevisionInProgressApprovedDateTime]
GO




GO

