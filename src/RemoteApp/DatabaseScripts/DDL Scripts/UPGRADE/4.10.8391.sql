

insert into RoleElement (Id, Name, FunctionalArea) values (225, 'Configure Site Communications', 'Admin - Site Configuration');
go

insert into RoleElementTemplate (RoleElementId, RoleId)
select 225, r.Id
from Role r
where r.Name in ('Administrator', 'Administrateur des Op�rations', 'Technical Administrator');






GO


CREATE TABLE [dbo].[SiteCommunication](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[Message] [varchar](300) NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL

 CONSTRAINT [PK_SiteCommunication] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SiteCommunication]  WITH CHECK ADD  CONSTRAINT [FK_SiteCommunication_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO

ALTER TABLE [dbo].[SiteCommunication] CHECK CONSTRAINT [FK_SiteCommunication_Site]
GO

ALTER TABLE [dbo].[SiteCommunication]  WITH CHECK ADD  CONSTRAINT [FK_SiteCommunication_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[SiteCommunication] CHECK CONSTRAINT [FK_SiteCommunication_CreatedByUser]
GO

ALTER TABLE [dbo].[SiteCommunication]  WITH CHECK ADD  CONSTRAINT [FK_SiteCommunication_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[SiteCommunication] CHECK CONSTRAINT [FK_SiteCommunication_LastModifiedByUser]
GO




GO

