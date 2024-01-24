
CREATE TABLE [dbo].[Event] (
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[SiteId] [bigint] NULL,
	[Name] [varchar](100) NOT NULL,
	[DateTime] [datetime] NOT NULL
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_User]
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Site]
GO


CREATE TABLE [dbo].[Property] (
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventId] [bigint] NOT NULL,
	[PropertyKey] [varchar](100) NOT NULL,
	[TypeId] [bigint] NOT NULL,
	[TextValue] [varchar](max) NULL,
	[DateTimeValue] [datetime] NULL,
	[NumberValue] [decimal](18, 6) NULL
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO

ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Event]
GO




GO

