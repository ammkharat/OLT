/****** Object:  Table [dbo].[ActionItemDefinitionSendEmail]    Script Date: 5/29/2019 9:28:33 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON


if EXists (SELECT * FROM   sys.columns  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionSendEmail]') AND name = 'Emails')
begin
drop table ActionItemDefinitionSendEmail
end

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ActionItemDefinitionSendEmail')
begin

CREATE TABLE [dbo].[ActionItemDefinitionSendEmail](
	[ActionItemDefinitionId] [bigint] NOT NULL,
	[SendEmail] [bit] NOT NULL
 CONSTRAINT [PK_ActionItemDefinitionSendEmail] PRIMARY KEY CLUSTERED 
(
	[ActionItemDefinitionId] ASC,
	[SendEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[ActionItemDefinitionSendEmail]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionSendEmail_ActionItemDefinition] FOREIGN KEY([ActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])

ALTER TABLE [dbo].[ActionItemDefinitionSendEmail] CHECK CONSTRAINT [FK_ActionItemDefinitionSendEmail_ActionItemDefinition]

end 


