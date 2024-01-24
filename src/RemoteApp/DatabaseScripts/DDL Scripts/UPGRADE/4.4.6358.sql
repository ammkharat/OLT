
create table [dbo].FormNumberSequence 
(
      SeqID bigint identity(1,1) primary key,
      SeqVal varchar(1)
)
GO


CREATE TABLE [dbo].[FormGN7](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FormNumber] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	
	[Deleted] [bit] NOT NULL DEFAULT ((0))
 CONSTRAINT [PK_FormGN7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FormGN7]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN7]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO





CREATE TABLE [dbo].[FormGN7FunctionalLocation](
	[FormGN7Id] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN7FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGN7Id] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FormGN7FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormGN7FunctionalLocation] CHECK CONSTRAINT [FK_FormGN7FunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[FormGN7FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7FunctionalLocation_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO
ALTER TABLE [dbo].[FormGN7FunctionalLocation] CHECK CONSTRAINT [FK_FormGN7FunctionalLocation_FormGN7]
GO


CREATE NONCLUSTERED INDEX [IDX_FormGN7FunctionalLocation] ON [dbo].[FormGN7FunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[FormGN7Id] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = ON) ON [PRIMARY]
GO





GO

