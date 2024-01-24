

alter table ShiftHandoverQuestionnaire add LogId bigint null;
go

ALTER TABLE [dbo].[ShiftHandoverQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaire_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO




GO

