
/****** Object:  Table [dbo].[ActionItemDefinitionCustomFieldGroup]    Script Date: 14/2/2019 3:50:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ActionItemDefinitionCustomFieldGroup') 
BEGIN


CREATE TABLE [dbo].[ActionItemDefinitionCustomFieldGroup](
	[ActionItemDefinitionId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_ActionItemDefinitionCustomFieldGroup] PRIMARY KEY CLUSTERED 
(
	[ActionItemDefinitionId] ASC,
	[CustomFieldGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[ActionItemDefinitionCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionCustomFieldGroup_ActionItemDefinition] FOREIGN KEY([ActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])


ALTER TABLE [dbo].[ActionItemDefinitionCustomFieldGroup] CHECK CONSTRAINT [FK_ActionItemDefinitionCustomFieldGroup_ActionItemDefinition]


ALTER TABLE [dbo].[ActionItemDefinitionCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionCustomFieldGroup_CustomFieldGroup] FOREIGN KEY([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])


ALTER TABLE [dbo].[ActionItemDefinitionCustomFieldGroup] CHECK CONSTRAINT [FK_ActionItemDefinitionCustomFieldGroup_CustomFieldGroup]

END


