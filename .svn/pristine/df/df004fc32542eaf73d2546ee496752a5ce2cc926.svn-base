
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PermitRequestEdmontonHistory](
	[Id] [bigint] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[OperationNumber] [varchar](4) NULL,
	[SubOperationNumber] [varchar](4) NULL,
	[Company] [varchar](50) NULL,
	[Supervisor] [varchar](100) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,	
	[WorkOrderNumber] [varchar](12) NULL,	
	[Trade] [varchar](100) NOT NULL,
	[Description] [varchar](400) NOT NULL,
	[SapDescription] [varchar](400) NULL,
	[Attributes] [varchar](max) NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_FunctionalLocation]
GO

ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_LastImportedByUser]
GO

ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_LastModifiedByUser]
GO

ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_LastSubmittedByUser] FOREIGN KEY([LastSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_LastSubmittedByUser]
GO






GO

