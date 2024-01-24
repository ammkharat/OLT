CREATE TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,	
	[DeviationAlertResponseId] [bigint] NULL,
	[RestrictionReasonCodeId] [bigint] NOT NULL,
	[ReasonCodeFunctionalLocationId] [bigint] NOT NULL,
	[AssignedAmount] int NOT NULL,
	[Comments] varchar(max),
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL

	CONSTRAINT [PK_DeviationAlertResponseReasonCodeAssignment] PRIMARY KEY ([Id] ASC)	
)

GO

ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]
ADD CONSTRAINT [FK_DeviationAlert_DeviationAlertResponse] 
FOREIGN KEY([DeviationAlertResponseId])
REFERENCES [dbo].[DeviationAlertResponse] ([Id])

GO

ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]
ADD CONSTRAINT [FK_DeviationAlert_RestrictionReasonCode] 
FOREIGN KEY([RestrictionReasonCodeId])
REFERENCES [dbo].[RestrictionReasonCode] ([Id])

GO

ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]
ADD CONSTRAINT [FK_DeviationAlert_ReasonCodeFunctionalLocation] 
FOREIGN KEY([ReasonCodeFunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO

ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]
ADD CONSTRAINT [FK_DeviationAlert_LastModifiedUser] 
FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])

GO

GO
