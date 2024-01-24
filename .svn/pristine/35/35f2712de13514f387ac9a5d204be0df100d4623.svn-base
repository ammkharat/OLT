CREATE TABLE [dbo].[FunctionalLocationAncestor](
	[Id] [bigint] NOT NULL,
	[AncestorId] [bigint] NOT NULL
) ON [PRIMARY]
GO

-- Child Level 2, Parent Level 1
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = c.siteid
and
c.level = 2
and
c.level > a.level
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
)

-- Child Level 3, Parent Level 1 and 2
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = c.siteid
and
c.level = 3
and
c.level > a.level
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
)

-- Child Level 4, Parent Level 3
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, c.parentid from FunctionalLocation c
where 
c.level = 4
and parentid is not null
)

-- Child Level 4, Parent Level 1 and 2
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = c.siteid
and
c.level = 4
and
a.level <= 2
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
)

-- Child Level 5, Parent Level 4
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, c.parentid from FunctionalLocation c
where 
c.level = 5
and parentid is not null
)

-- Child Level 5, Parent Level 3
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, c.unitid from FunctionalLocation c
where 
c.level = 5
and unitid is not null
)

-- Child Level 5, Parent Level 2
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = c.siteid
and
c.level = 5
and
a.level = 2
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
)

-- Child Level 5, Parent Level 1
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = c.siteid
and
c.level = 5
and
a.level = 1
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
)


ALTER TABLE [dbo].[FunctionalLocationAncestor]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocationAncestor_AncestorId] FOREIGN KEY([AncestorId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FunctionalLocationAncestor] CHECK CONSTRAINT [FK_FunctionalLocationAncestor_AncestorId]
GO
ALTER TABLE [dbo].[FunctionalLocationAncestor]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocationAncestor_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FunctionalLocationAncestor] CHECK CONSTRAINT [FK_FunctionalLocationAncestor_Id]
GO

CREATE UNIQUE CLUSTERED INDEX [IDX_FunctionalLocationAncestor] ON [dbo].[FunctionalLocationAncestor] 
(
	[Id],
	[AncestorId] 
)
GO
GO
