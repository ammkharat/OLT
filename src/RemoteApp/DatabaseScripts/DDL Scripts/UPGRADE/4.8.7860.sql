


CREATE TABLE [dbo].[LogWorkPermitLubesAssociation](
	[LogId] [bigint] NOT NULL,
	[WorkPermitLubesId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogWorkPermitLubesAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LogWorkPermitLubesAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitLubesAssoc_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO

ALTER TABLE [dbo].[LogWorkPermitLubesAssociation] CHECK CONSTRAINT [FK_LogWorkPermitLubesAssoc_Log]
GO

ALTER TABLE [dbo].[LogWorkPermitLubesAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitLubesAssoc_WorkPermit] FOREIGN KEY([WorkPermitLubesId])
REFERENCES [dbo].[WorkPermitLubes] ([Id])
GO

ALTER TABLE [dbo].[LogWorkPermitLubesAssociation] CHECK CONSTRAINT [FK_LogWorkPermitLubesAssoc_WorkPermit]
GO


---------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------

insert into WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) values (10, 4, 0);
insert into WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) values (10, 6, 0);
insert into WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) values (10, 7, 0);
insert into WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) values (10, 8, 0);
insert into WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) values (10, 11, 0);
insert into WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) values (10, 5, 0);








GO

