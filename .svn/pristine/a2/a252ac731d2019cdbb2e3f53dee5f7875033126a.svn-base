CREATE TABLE [dbo].[SummaryLogFunctionalLocation](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[SummaryLogId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
CONSTRAINT [PK_SummaryLogFunctionalLocation] PRIMARY KEY ([Id] ASC))

GO

ALTER TABLE [dbo].[SummaryLogFunctionalLocation]
ADD CONSTRAINT [FK_SummaryLogFunctionalLocation_SummaryLog] 
FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])

GO

ALTER TABLE [dbo].[SummaryLogFunctionalLocation]
ADD CONSTRAINT [FK_SummaryLogFunctionalLocation_FuncationalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO

-- INSERT EXISTING RECORDS INTO SummaryLog table
INSERT INTO SummaryLogFunctionalLocation
SELECT Id, FunctionalLocationId FROM SummaryLog
GO

alter table SummaryLog drop column FunctionalLocationId

GO

