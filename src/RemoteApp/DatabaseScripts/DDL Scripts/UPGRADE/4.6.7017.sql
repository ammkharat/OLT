
CREATE TABLE [dbo].[WorkPermitFunctionalLocationConfiguration](
	[WorkAssignmentId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitFunctionalLocationConfiguration] PRIMARY KEY CLUSTERED 
(
	[WorkAssignmentId] ASC,
	[FunctionalLocationId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WorkPermitFunctionalLocationConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFunctionalLocationConfiguration_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[WorkPermitFunctionalLocationConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFunctionalLocationConfiguration_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])


GO

