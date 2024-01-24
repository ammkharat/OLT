CREATE TABLE [dbo].[WorkPermitEdmontonGroup](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] varchar(100) NOT NULL,
	[SAPImportPriorityList] varchar(30) NULL,
	[DisplayOrder] int NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitEdmontonGroup] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert into WorkPermitEdmontonGroup (Name, SAPImportPriorityList, DisplayOrder, Deleted) values ('Maintenance', 'P0,P1,P2', 0, 0);
insert into WorkPermitEdmontonGroup (Name, SAPImportPriorityList, DisplayOrder, Deleted) values ('Construction', null, 1, 0);
insert into WorkPermitEdmontonGroup (Name, SAPImportPriorityList, DisplayOrder, Deleted) values ('Turnaround', 'P3', 2, 0);
insert into WorkPermitEdmontonGroup (Name, SAPImportPriorityList, DisplayOrder, Deleted) values ('Outage', 'P4', 3, 0);
GO

--convert group to GroupId on the PermitRequestEdmonton
update PermitRequestEdmonton set [Group] = null;
GO

alter table PermitRequestEdmonton alter column [Group] bigint not null;
GO

sp_RENAME 'PermitRequestEdmonton.[Group]' , 'GroupId', 'COLUMN'
GO

ALTER TABLE [dbo].[PermitRequestEdmonton] WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmonton_WorkPermitEdmontonGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[WorkPermitEdmontonGroup] ([Id]);
GO

--convert group to GroupId on the WorkPermitEdmonton
update WorkPermitEdmonton set [Group] = null;
GO

alter table WorkPermitEdmonton alter column [Group] bigint not null;
GO

sp_RENAME 'WorkPermitEdmonton.[Group]' , 'GroupId', 'COLUMN'
GO

ALTER TABLE [dbo].[WorkPermitEdmonton] WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmonton_WorkPermitEdmontonGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[WorkPermitEdmontonGroup] ([Id]);
GO




GO

