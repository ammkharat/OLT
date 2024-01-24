
/****** Object:  Table [dbo].[FormGN75BSarniaIsolationItem]    Script Date: 8/7/2018 3:50:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormGN75BSarniaIsolationItem') 
BEGIN



CREATE TABLE [dbo].[FormGN75BSarniaIsolationItem](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN75BTemplateId] [bigint] NOT NULL,
	[IsolationType] [varchar](100) NOT NULL,
	[LocationOfEnergyIsolation] [varchar](500) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Siteid] [bigint] NULL,
	[DevicePosition] [varchar](20) NULL,
 CONSTRAINT [PK_FormGN75BSarniaIsolationItem_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[FormGN75BSarniaIsolationItem] ADD  DEFAULT ((0)) FOR [Deleted]


ALTER TABLE [dbo].[FormGN75BSarniaIsolationItem]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BSarniaIsolationItem_FormGN75BTemplate] FOREIGN KEY([FormGN75BTemplateId])
REFERENCES [dbo].[FormGN75BTemplate] ([Id])


ALTER TABLE [dbo].[FormGN75BSarniaIsolationItem] CHECK CONSTRAINT [FK_FormGN75BSarniaIsolationItem_FormGN75BTemplate]

END

