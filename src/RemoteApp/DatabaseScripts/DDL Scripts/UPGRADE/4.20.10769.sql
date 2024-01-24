SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

ALTER TABLE [dbo].[FormDocumentSuggestion] ADD [NotApprovedReason] varchar(255) NULL
GO

ALTER TABLE [dbo].[FormDocumentSuggestionHistory] ADD [NotApprovedReason] varchar(255) NULL
GO



GO

