

CREATE TABLE [dbo].[FormGN7History] (
	[Id] bigint NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [varchar](MAX) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_FormGN7History]
ON [dbo].[FormGN7History]
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

ALTER TABLE [dbo].[FormGN7History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN7History] CHECK CONSTRAINT [FK_FormGN7History_LastModifiedByUser]

GO


alter table dbo.FormGN7 add PlainTextContent varchar(max) NULL
go







GO

