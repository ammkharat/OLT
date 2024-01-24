SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER TABLE [dbo].[FormDocumentSuggestion] ADD [MaxEndDateTime] AS IsNull(IsNull(NotApprovedDateTime, IsNull(DocumentArchivedApprovedDateTime, DocumentIssuedApprovedDateTime)), IsNull(ScheduledCompletionDateTime, ValidToDateTime))
GO



GO

