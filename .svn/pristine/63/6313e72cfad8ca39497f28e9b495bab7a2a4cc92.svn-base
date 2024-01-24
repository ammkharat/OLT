IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormGN75BTemplateIsolationItem')

BEGIN

CREATE TABLE [dbo].[FormGN75BTemplateIsolationItem](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN75BTemplateId] [bigint] NOT NULL,
	[IsolationType] [varchar](100) NOT NULL,
	[LocationOfEnergyIsolation] [varchar](500) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Siteid] [bigint] NULL,
	[DevicePosition] [varchar](20) NULL,
 CONSTRAINT [PK_FormGN75BTemplateIsolationItem_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[FormGN75BTemplateIsolationItem] ADD  DEFAULT ((0)) FOR [Deleted]

ALTER TABLE [dbo].[FormGN75BTemplateIsolationItem]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75IsolationItem_FormGN75BTemplate] FOREIGN KEY([FormGN75BTemplateId])
REFERENCES [dbo].[FormGN75BTemplate] ([Id])

ALTER TABLE [dbo].[FormGN75BTemplateIsolationItem] CHECK CONSTRAINT [FK_FormGN75IsolationItem_FormGN75BTemplate]

End

