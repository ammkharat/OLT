
/****** Object:  Table [dbo].[FormGN75BSarniaDevicePosition]    Script Date: 8/7/2018 3:50:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormGN75BSarniaDevicePosition') 
BEGIN



CREATE TABLE [dbo].[FormGN75BSarniaDevicePosition](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN75BTemplateId] [bigint] NOT NULL,
	[DevicePosition] [varchar](20) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN75BTemplateDevicePosition_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[FormGN75BSarniaDevicePosition] ADD  DEFAULT ((0)) FOR [Deleted]


ALTER TABLE [dbo].[FormGN75BSarniaDevicePosition]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BSarniaDevicePosition_FormGN75BTemplate] FOREIGN KEY([FormGN75BTemplateId])
REFERENCES [dbo].[FormGN75BTemplate] ([Id])


ALTER TABLE [dbo].[FormGN75BSarniaDevicePosition] CHECK CONSTRAINT [FK_FormGN75BSarniaDevicePosition_FormGN75BTemplate]


END


