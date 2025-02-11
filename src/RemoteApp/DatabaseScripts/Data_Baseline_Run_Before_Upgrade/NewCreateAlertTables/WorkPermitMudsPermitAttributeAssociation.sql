IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsPermitAttributeAssociation]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[WorkPermitMudsPermitAttributeAssociation](
	[WorkPermitMudsId] [bigint] NOT NULL,
	[PermitAttributeId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitMudsPermitAttribAssoc] PRIMARY KEY CLUSTERED 
(
	[WorkPermitMudsId] ASC,
	[PermitAttributeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

--ALTER TABLE [dbo].[WorkPermitMudsPermitAttributeAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMudsPermitAttributeAssociation_PermitAttribute] FOREIGN KEY([PermitAttributeId])
--REFERENCES [dbo].[PermitAttribute] ([Id])

--ALTER TABLE [dbo].[WorkPermitMudsPermitAttributeAssociation] CHECK CONSTRAINT [FK_WorkPermitMudsPermitAttributeAssociation_PermitAttribute]

--ALTER TABLE [dbo].[WorkPermitMudsPermitAttributeAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMudsPermitAttributeAssociation_WorkPermitMuds] FOREIGN KEY([WorkPermitMudsId])
--REFERENCES [dbo].[WorkPermitMuds] ([Id])

--ALTER TABLE [dbo].[WorkPermitMudsPermitAttributeAssociation] CHECK CONSTRAINT [FK_WorkPermitMudsPermitAttributeAssociation_WorkPermitMuds]


End