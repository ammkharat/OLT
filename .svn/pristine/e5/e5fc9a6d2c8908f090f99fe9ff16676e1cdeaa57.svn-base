
CREATE TABLE [dbo].[WorkPermitLubesGroup](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL
 CONSTRAINT [PK_WorkPermitLubesGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



insert into WorkPermitLubesGroup (Name, DisplayOrder, Deleted) values ('Maintenance', 1, 0)
insert into WorkPermitLubesGroup (Name, DisplayOrder, Deleted) values ('Construction', 2, 0)
insert into WorkPermitLubesGroup (Name, DisplayOrder, Deleted) values ('Turnaround', 3, 0)
insert into WorkPermitLubesGroup (Name, DisplayOrder, Deleted) values ('Outage', 4, 0)
go



alter table WorkPermitLubes alter column RequestedByGroup bigint not null;
go

EXEC sp_rename 'WorkPermitLubes.RequestedByGroup', 'RequestedByGroupId', 'COLUMN';
go

ALTER TABLE [dbo].[WorkPermitLubes]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubes_WorkPermitLubesGroup] FOREIGN KEY([RequestedByGroupId])
REFERENCES [dbo].[WorkPermitLubesGroup] ([Id])
GO





GO

