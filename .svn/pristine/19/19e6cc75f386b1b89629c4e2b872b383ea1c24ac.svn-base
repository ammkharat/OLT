

CREATE TABLE [dbo].[FormGN59History] (
	[Id] bigint NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [varchar](MAX) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[ReleasedDateTime] [datetime] NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_FormGN59History]
ON [dbo].[FormGN59History]
([Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 90,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[FormGN59History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN59History] CHECK CONSTRAINT [FK_FormGN59History_LastModifiedByUser]



GO

