
/****** Object:  Table [dbo].[ActionItemCustomFieldEntry]    Script Date: 8/7/2018 3:50:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ActionItemCustomFieldEntry') 
BEGIN


CREATE TABLE [dbo].[ActionItemCustomFieldEntry](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[ActionItemId] [bigint] NOT NULL,
	[ActionItemCustomFieldName] [varchar](100) NOT NULL,
	[FieldEntry] [varchar](100) NULL,
	[DisplayOrder] [int] NOT NULL,
	[TypeId] [tinyint] NOT NULL,
	[NumericFieldEntry] [decimal](18, 6) NULL,
	[CustomFieldId] [bigint] NOT NULL,
	[PHDLinkTypeId] [tinyint] NOT NULL,
 CONSTRAINT [PK_ActionItemCustomFieldEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[ActionItemCustomFieldEntry]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemCustomFieldEntry_CustomField] FOREIGN KEY([CustomFieldId])
REFERENCES [dbo].[CustomField] ([Id])


ALTER TABLE [dbo].[ActionItemCustomFieldEntry] CHECK CONSTRAINT [FK_ActionItemCustomFieldEntry_CustomField]


ALTER TABLE [dbo].[ActionItemCustomFieldEntry]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemCustomFieldEntry_ActionItem] FOREIGN KEY([ActionItemId])
REFERENCES [dbo].[ActionItem] ([Id])


ALTER TABLE [dbo].[ActionItemCustomFieldEntry] CHECK CONSTRAINT [FK_ActionItemCustomFieldEntry_ActionItem]

end

