
CREATE TABLE [dbo].[WorkPermitMontrealGroup](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL
 CONSTRAINT [PK_WorkPermitMontrealGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into WorkPermitMontrealGroup (Name, DisplayOrder, Deleted) values ('Maintenance', 1, 0)
insert into WorkPermitMontrealGroup (Name, DisplayOrder, Deleted) values ('Projets', 2, 0)
insert into WorkPermitMontrealGroup (Name, DisplayOrder, Deleted) values ('Arrêt d’unité', 3, 0)
insert into WorkPermitMontrealGroup (Name, DisplayOrder, Deleted) values ('Interruption', 4, 0)
go



alter table WorkPermitMontreal add RequestedByGroupId bigint null;
go

ALTER TABLE [dbo].[WorkPermitMontreal]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontreal_WorkPermitMontrealGroup] FOREIGN KEY([RequestedByGroupId])
REFERENCES [dbo].[WorkPermitMontrealGroup] ([Id])
GO

ALTER TABLE [dbo].[WorkPermitMontreal] CHECK CONSTRAINT [FK_WorkPermitMontreal_WorkPermitMontrealGroup]
GO

alter table WorkPermitMontrealHistory add RequestedByGroup varchar(100) null;
go

------------------------------------------------------

alter table PermitRequestMontreal add RequestedByGroupId bigint null;
go

ALTER TABLE [dbo].[PermitRequestMontreal]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontreal_WorkPermitMontrealGroup] FOREIGN KEY([RequestedByGroupId])
REFERENCES [dbo].[WorkPermitMontrealGroup] ([Id])
GO

ALTER TABLE [dbo].[PermitRequestMontreal] CHECK CONSTRAINT [FK_PermitRequestMontreal_WorkPermitMontrealGroup]
GO

alter table PermitRequestMontrealHistory add RequestedByGroup varchar(100) null;
go








GO

