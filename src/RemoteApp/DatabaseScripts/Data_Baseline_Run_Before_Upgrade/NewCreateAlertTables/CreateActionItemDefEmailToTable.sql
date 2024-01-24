IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ActionItemDefinitionEmailToRecipient') 
begin
CREATE TABLE [dbo].[ActionItemDefinitionEmailToRecipient](
	[ActionItemDefinitionId] [bigint] NOT NULL,
	[EmailTo] [varchar](100) NOT NULL
 CONSTRAINT [PK_ActionItemDefinitionEmailTo] PRIMARY KEY CLUSTERED 
(
	[ActionItemDefinitionId] ASC,
	[EmailTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[ActionItemDefinitionEmailToRecipient]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionEmailTo_ActionItemDefinition] FOREIGN KEY([ActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])

ALTER TABLE [dbo].[ActionItemDefinitionEmailToRecipient] CHECK CONSTRAINT [FK_ActionItemDefinitionEmailTo_ActionItemDefinition]

end 




