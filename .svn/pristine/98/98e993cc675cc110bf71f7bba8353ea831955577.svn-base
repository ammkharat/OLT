
CREATE TABLE [dbo].[LogFunctionalLocation](
	[LogId] bigint NOT NULL,
	[FunctionalLocationId] bigint NOT NULL
			
	CONSTRAINT [PK_LogFunctionalLocation] PRIMARY KEY CLUSTERED
	(
		[LogId] ASC,
		[FunctionalLocationId] ASC
	)		
)
GO

ALTER TABLE [dbo].[LogFunctionalLocation]
ADD CONSTRAINT [FK_LogFunctionalLocation_Log]
FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO

ALTER TABLE [dbo].[LogFunctionalLocation]
ADD CONSTRAINT [FK_LogFunctionalLocation_FunctionalLocation]
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

INSERT INTO [dbo].LogFunctionalLocation
SELECT Id, FunctionalLocationId FROM [dbo].[Log]
GO

ALTER TABLE [dbo].[Log]
DROP CONSTRAINT FK_Log_FunctionalLocation
GO

DROP INDEX IDX_LOG_FLOC ON [dbo].[Log]
GO

alter table [dbo].[Log] drop column FunctionalLocationId
GO


GO
