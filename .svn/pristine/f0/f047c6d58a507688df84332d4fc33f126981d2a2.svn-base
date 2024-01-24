
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ActionItemWorkPermitFortHillsAssociation]') AND type in (N'U'))

BEGIN


CREATE TABLE [dbo].[ActionItemWorkPermitFortHillsAssociation](
	[ActionItemId] [bigint] NOT NULL,
	[WorkPermitFortHillsId] [bigint] NOT NULL,
 CONSTRAINT [PK_ActionItemWorkPermitFortHillsAssociation] PRIMARY KEY CLUSTERED 
(
	[ActionItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

--GO

--ALTER TABLE [dbo].[ActionItemWorkPermitFortHillsAssociation]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemWorkPermitFortHillsAssoc_ActionItem] FOREIGN KEY([ActionItemId])
--REFERENCES [dbo].[ActionItemDefinition] ([Id])
--GO

--ALTER TABLE [dbo].[ActionItemWorkPermitFortHillsAssociation] CHECK CONSTRAINT [FK_ActionItemWorkPermitFortHillsAssoc_ActionItem]
--GO

--ALTER TABLE [dbo].[ActionItemWorkPermitFortHillsAssociation]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemWorkPermitFortHillsAssoc_WorkPermit] FOREIGN KEY([WorkPermitFortHillsId])
--REFERENCES [dbo].[WorkPermitFortHills] ([Id])
--GO

--ALTER TABLE [dbo].[ActionItemWorkPermitFortHillsAssociation] CHECK CONSTRAINT [FK_ActionItemWorkPermitFortHillsAssoc_WorkPermit]
--GO

END
