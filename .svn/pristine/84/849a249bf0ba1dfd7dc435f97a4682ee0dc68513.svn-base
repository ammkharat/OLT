CREATE TABLE dbo.SiteRoleConfiguration(
	Id bigint IDENTITY(1,1) NOT NULL,
	SiteId bigint NOT NULL,
	RoleId bigint NOT NULL,
	WarnIfWorkAssignmentNotSelected bit NOT NULL
	CONSTRAINT [PK_SiteRoleConfiguration] PRIMARY KEY CLUSTERED 
	(
		Id ASC
	),
	CONSTRAINT UQ_SiteRoleConfiguration UNIQUE NONCLUSTERED 
	(	
		SiteId ASC,
		RoleId ASC
	)
)

GO

ALTER TABLE dbo.SiteRoleConfiguration
ADD CONSTRAINT FK_SiteRoleConfiguration_Site 
FOREIGN KEY(SiteId)
REFERENCES dbo.Site (Id)

GO

ALTER TABLE dbo.SiteRoleConfiguration
ADD CONSTRAINT FK_SiteRoleConfiguration_Role 
FOREIGN KEY(RoleId)
REFERENCES dbo.Role (Id)

GO

insert into SiteRoleConfiguration select 3, Id, 1 from Role where id in (1, 2, 41, 42, 43, 44) and Deleted = 0;
insert into SiteRoleConfiguration select 8, Id, 1 from Role where id in (1, 2) and Deleted = 0;

GO


GO
