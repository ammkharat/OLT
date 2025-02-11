IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsFunctionalLocation]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[WorkPermitMudsFunctionalLocation](
	[WorkPermitMudsId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitMudsFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[WorkPermitMudsId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

--ALTER TABLE [dbo].[WorkPermitMudsFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMudsFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
--REFERENCES [dbo].[FunctionalLocation] ([Id])

--ALTER TABLE [dbo].[WorkPermitMudsFunctionalLocation] CHECK CONSTRAINT [FK_WorkPermitMudsFunctionalLocation_FunctionalLocation]

--ALTER TABLE [dbo].[WorkPermitMudsFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMudsFunctionalLocation_WorkPermitMuds] FOREIGN KEY([WorkPermitMudsId])
--REFERENCES [dbo].[WorkPermitMuds] ([Id])

--ALTER TABLE [dbo].[WorkPermitMudsFunctionalLocation] CHECK CONSTRAINT [FK_WorkPermitMudsFunctionalLocation_WorkPermitMuds]


End
