SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

ALTER TABLE [dbo].[DocumentLink] ADD [FormDocumentSuggestionId] bigint NULL
GO

ALTER TABLE [dbo].[DocumentLink] ADD CONSTRAINT [FK_DocumentLink_FormDocumentSuggestion]
FOREIGN KEY ([FormDocumentSuggestionId]) REFERENCES [dbo].[FormDocumentSuggestion] ([Id])
GO



GO

