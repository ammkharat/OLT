
/****** Object:  Table [dbo].[ActionItemCustomFieldGroup]    Script Date: 8/7/2018 3:50:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ActionItemCustomFieldGroup') 
BEGIN

CREATE TABLE [dbo].[ActionItemCustomFieldGroup](
	[ActionItemId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_ActionItemCustomFieldGroup] PRIMARY KEY CLUSTERED 
(
	[ActionItemId] ASC,
	[CustomFieldGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[ActionItemCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemCustomFieldGroup_CustomFieldGroup] FOREIGN KEY([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])


ALTER TABLE [dbo].[ActionItemCustomFieldGroup] CHECK CONSTRAINT [FK_ActionItemCustomFieldGroup_CustomFieldGroup]


ALTER TABLE [dbo].[ActionItemCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemCustomFieldGroup_ActionItem] FOREIGN KEY([ActionItemId])
REFERENCES [dbo].[ActionItem] ([Id])


ALTER TABLE [dbo].[ActionItemCustomFieldGroup] CHECK CONSTRAINT [FK_ActionItemCustomFieldGroup_ActionItem]
END


