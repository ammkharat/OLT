IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[LogWorkPermitMudsAssociation]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[LogWorkPermitMudsAssociation](
	[LogId] [bigint] NOT NULL,
	[WorkPermitMudsId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogWorkPermitMudsAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

--ALTER TABLE [dbo].[LogWorkPermitMudsAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitMudsAssoc_Log] FOREIGN KEY([LogId])
--REFERENCES [dbo].[Log] ([Id])

--ALTER TABLE [dbo].[LogWorkPermitMudsAssociation] CHECK CONSTRAINT [FK_LogWorkPermitMudsAssoc_Log]

--ALTER TABLE [dbo].[LogWorkPermitMudsAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitMudsAssoc_WorkPermit] FOREIGN KEY([WorkPermitMudsId])
--REFERENCES [dbo].[WorkPermitMuds] ([Id])

--ALTER TABLE [dbo].[LogWorkPermitMudsAssociation] CHECK CONSTRAINT [FK_LogWorkPermitMudsAssoc_WorkPermit]


End