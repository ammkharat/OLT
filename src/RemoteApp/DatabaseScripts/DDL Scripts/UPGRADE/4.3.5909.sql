ALTER TABLE [dbo].[SummaryLog]  WITH CHECK ADD CONSTRAINT [FK_SummaryLog_ReplyToLog] FOREIGN KEY([ReplyToLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[SummaryLog] CHECK CONSTRAINT [FK_SummaryLog_ReplyToLog]

GO

ALTER TABLE [dbo].[SummaryLog] WITH CHECK ADD CONSTRAINT [FK_SummaryLog_RootLog] FOREIGN KEY([RootLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[SummaryLog] CHECK CONSTRAINT [FK_SummaryLog_RootLog]


GO

