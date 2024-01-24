CREATE TABLE [dbo].[DeviationAlertResponse](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,		
	[CreatedDateTime] [DateTime] NOT NULL,
	[LastModifiedDateTime] [DateTime] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL
		
	CONSTRAINT [PK_DeviationAlertResponse] PRIMARY KEY ([Id] ASC)	
)
GO

ALTER TABLE [dbo].[DeviationAlertResponse]
ADD CONSTRAINT [FK_DeviationAlertResponse_LastModifiedUser] 
FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])

GO

CREATE TABLE [dbo].[DeviationAlertResponseReasonAllocation](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,	
	[DeviationAlertResponseId] [bigint] NOT NULL,
	[ReasonCodeId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[CreatedDateTime] [DateTime] NOT NULL,
	[LastModifiedDateTime] [DateTime] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL
		
	CONSTRAINT [PK_DeviationAlertResponseReasonAllocation] PRIMARY KEY ([Id] ASC)	
)
GO

ALTER TABLE [dbo].[DeviationAlertResponseReasonAllocation]
ADD CONSTRAINT [FK_DeviationAlertResponseReasonAllocation_DeviationAlertResponse] 
FOREIGN KEY([DeviationAlertResponseId])
REFERENCES [dbo].[DeviationAlertResponse] ([Id])

GO

ALTER TABLE [dbo].[DeviationAlertResponseReasonAllocation]
ADD CONSTRAINT [FK_DeviationAlertResponseReasonAllocation_ReasonCode] 
FOREIGN KEY([ReasonCodeId])
REFERENCES [dbo].[RestrictionReasonCode] ([Id])

GO

ALTER TABLE [dbo].[DeviationAlertResponseReasonAllocation]
ADD CONSTRAINT [FK_DeviationAlertResponseReasonAllocation_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO

ALTER TABLE [dbo].[DeviationAlertResponseReasonAllocation]
ADD CONSTRAINT [FK_DeviationAlertResponseReasonAllocation_LastModifiedUser] 
FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])

GO


GO
