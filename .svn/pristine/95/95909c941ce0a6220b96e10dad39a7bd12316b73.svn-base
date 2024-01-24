

alter table ShiftHandoverQuestionnaire add SummaryLogId bigint null;
go

ALTER TABLE [dbo].[ShiftHandoverQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaire_SummaryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO



GO

