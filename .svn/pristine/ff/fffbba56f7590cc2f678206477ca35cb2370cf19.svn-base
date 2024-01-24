


CREATE TABLE [dbo].[LogWorkPermitMontrealAssociation](
	[LogId] [bigint] NOT NULL,
	[WorkPermitMontrealId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogWorkPermitMontrealAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LogWorkPermitMontrealAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitMontrealAssoc_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO

ALTER TABLE [dbo].[LogWorkPermitMontrealAssociation] CHECK CONSTRAINT [FK_LogWorkPermitMontrealAssoc_Log]
GO

ALTER TABLE [dbo].[LogWorkPermitMontrealAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitMontrealAssoc_WorkPermit] FOREIGN KEY([WorkPermitMontrealId])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
GO

ALTER TABLE [dbo].[LogWorkPermitMontrealAssociation] CHECK CONSTRAINT [FK_LogWorkPermitMontrealAssoc_WorkPermit]
GO










GO

