IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGenericTemplateHistory]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[FormGenericTemplateHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
	[DocumentLinks] [varchar](max) NULL
) ON [PRIMARY]



SET ANSI_PADDING OFF


ALTER TABLE [dbo].[FormGenericTemplateHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGenericTemplateHistory] CHECK CONSTRAINT [FK_FormGenericTemplateHistory_LastModifiedByUser]



End

