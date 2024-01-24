
CREATE TABLE [dbo].[LogWorkPermitOssaAssociation](
	[LogId] [bigint] NOT NULL,
	[WorkPermitOssaId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogWorkPermitOssaAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LogWorkPermitOssaAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitOssaAssociation_WorkPermitOssa] FOREIGN KEY([WorkPermitOssaId])
REFERENCES [dbo].[WorkPermitOssa] ([Id])
GO

ALTER TABLE [dbo].[LogWorkPermitOssaAssociation] CHECK CONSTRAINT [FK_LogWorkPermitOssaAssociation_WorkPermitOssa]
GO

ALTER TABLE [dbo].[LogWorkPermitOssaAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitOssaAssociation_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO

ALTER TABLE [dbo].[LogWorkPermitOssaAssociation] CHECK CONSTRAINT [FK_LogWorkPermitOssaAssociation_Log]
GO




GO

