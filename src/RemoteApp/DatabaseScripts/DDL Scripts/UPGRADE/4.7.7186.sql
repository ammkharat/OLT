CREATE TABLE [dbo].[GroupVisibility] (
  [Id] bigint IDENTITY(1, 1) NOT NULL,
  [Name] varchar(100) NOT NULL,
  [SiteId] bigint NOT NULL,
  CONSTRAINT [PK_GroupVisibility] PRIMARY KEY CLUSTERED ([Id] )
    WITH ( PAD_INDEX = OFF, 
          FILLFACTOR = 100, 
          IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON )
    ON [PRIMARY],
  CONSTRAINT [FK_GroupVisibility_SiteId] FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Site] ( [Id] ),
  UNIQUE NONCLUSTERED ([SiteId] , [Name] )
    WITH ( PAD_INDEX = OFF, FILLFACTOR = 100, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
          ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)

CREATE TABLE [dbo].[WorkAssignmentGroupVisibility] (
  [Id] bigint IDENTITY(1, 1) NOT NULL,
  [GroupId] bigint NOT NULL,
  [WorkAssignmentId] bigint NOT NULL,
  [VisibilityType] tinyint NOT NULL,
  CONSTRAINT [PK_WorkAssignmentGroupVisibility]
  PRIMARY KEY CLUSTERED ([Id] )
    WITH ( PAD_INDEX = OFF, FILLFACTOR = 100, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON )
    ON [PRIMARY],
  CONSTRAINT [IDX_WorkAssignmentGroupVisibility_WorkAssignment]
    FOREIGN KEY ([WorkAssignmentId])
    REFERENCES [dbo].[WorkAssignment] ( [Id] ),
  CONSTRAINT [IDX_WorkAssignmentGroupVisibility_Group]
    FOREIGN KEY ([GroupId])
    REFERENCES [dbo].[GroupVisibility] ( [Id] )
)

-- create the default 'Operations' Group for each site.
INSERT INTO dbo.[GroupVisibility] 
  SELECT 'Operations',[Id]
    FROM [Site]
GO

-- create READ of operations group for every work assignment in all sites
INSERT INTO dbo.WorkAssignmentGroupVisibility  
select [GroupVisibility].[Id], WorkAssignment.Id, 1 from WorkAssignment
inner join dbo.[Role] ON dbo.WorkAssignment.RoleId = dbo.[Role].Id
inner join dbo.[GroupVisibility] ON dbo.[GroupVisibility].SiteId = dbo.[Role].SiteId

-- create WRITE of operations group for every work assignment in all sites where the Role does not begin with 'TA '
INSERT INTO dbo.WorkAssignmentGroupVisibility  
select [GroupVisibility].[Id], WorkAssignment.Id, 2 from WorkAssignment
inner join dbo.[Role] ON dbo.WorkAssignment.RoleId = dbo.[Role].Id
inner join dbo.[GroupVisibility] ON dbo.[GroupVisibility].SiteId = dbo.[Role].SiteId
where dbo.[Role].[Name] not like 'TA %'



GO

