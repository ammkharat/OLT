CREATE TABLE [dbo].[FutureLogReferenceCriteria](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,		
	[SummaryLogId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NULL,	
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL	
		
	CONSTRAINT [PK_FutureLogReferenceCriteria] PRIMARY KEY ([Id] ASC)	
)

ALTER TABLE [dbo].[FutureLogReferenceCriteria]
ADD CONSTRAINT [FK_FutureLogReferenceCriteria_Log] 
FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[Log] ([Id])

GO

ALTER TABLE [dbo].[FutureLogReferenceCriteria]
ADD CONSTRAINT [FK_FutureLogReferenceCriteria_WorkAssignment] 
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])

GO





GO
