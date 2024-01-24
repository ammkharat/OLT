
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormMudsTemporaryInstallationFunctionalLocation') 

Begin

SET ANSI_NULLS ON


SET QUOTED_IDENTIFIER ON


CREATE TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation](
	[FormMudsTemporaryInstallationId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormMudsTemporaryInstallationFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormMudsTemporaryInstallationId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormMudsTemporaryInstallationFunctionalLocation_FormMudsTemporaryInstallation] FOREIGN KEY([FormMudsTemporaryInstallationId])
REFERENCES [dbo].[FormMudsTemporaryInstallation] ([Id])


ALTER TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation] CHECK CONSTRAINT [FK_FormMudsTemporaryInstallationFunctionalLocation_FormMudsTemporaryInstallation]


ALTER TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormMudsTemporaryInstallationFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])


ALTER TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation] CHECK CONSTRAINT [FK_FormMudsTemporaryInstallationFunctionalLocation_FunctionalLocation]



End