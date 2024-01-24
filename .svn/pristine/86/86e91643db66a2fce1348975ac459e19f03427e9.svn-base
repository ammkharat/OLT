CREATE TABLE [dbo].[SummaryLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,			
	[LoggedDate] [datetime] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Comments] [varchar](max) NOT NULL,
	[EHSFollowup] [bit] NOT NULL,
	[InspectionFollowUp] [bit] NOT NULL,
	[ProcessControlFollowUp] [bit] NOT NULL,
	[OperationsFollowUp] [bit] NOT NULL,
	[SupervisionFollowUp] [bit] NOT NULL,
	[OtherFollowUp] [bit] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreationUserShiftPatternId] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL DEFAULT ((0)),						
	[WorkAssignmentId] [bigint] NULL,
 CONSTRAINT [PK_SummaryLog] PRIMARY KEY ([Id] ASC)
)
	
ALTER TABLE [dbo].[SummaryLog] ADD CONSTRAINT [FK_SummaryLog_LastModifiedUser] 
FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[SummaryLog] ADD CONSTRAINT [FK_SummaryLog_WorkAssignment] 
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO

ALTER TABLE [dbo].[SummaryLog] ADD CONSTRAINT [FK_SummaryLog_Shift] 
FOREIGN KEY([CreationUserShiftPatternId])
REFERENCES [dbo].[Shift] ([Id])
GO

ALTER TABLE [dbo].[SummaryLog] ADD CONSTRAINT [FK_SummaryLog_User] 
FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

GO
