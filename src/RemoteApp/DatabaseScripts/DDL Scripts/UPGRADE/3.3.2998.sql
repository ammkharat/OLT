ALTER TABLE TargetAlert DROP COLUMN bwtarget
ALTER TABLE TargetDefinition DROP COLUMN bwtarget
ALTER TABLE TargetDefinitionHistory DROP COLUMN bwtarget

GO





CREATE TABLE dbo.SiteRoleDisplayConfiguration(
	Id bigint IDENTITY(1,1) NOT NULL,
	SiteId bigint NOT NULL,
	RoleId bigint NOT NULL,
	SectionId int NOT NULL,
	PrimaryDefaultPageId int NOT NULL,
	SecondaryDefaultPageId int NULL,
	CONSTRAINT [PK_SiteRoleDisplayConfiguration] PRIMARY KEY CLUSTERED 
	(
		Id ASC
	),
	CONSTRAINT UQ_SiteRoleDisplayConfiguration UNIQUE NONCLUSTERED 
	(	
		SiteId ASC,
		RoleId ASC,
		SectionId ASC		
	)
)

GO

ALTER TABLE dbo.SiteRoleDisplayConfiguration
ADD CONSTRAINT FK_SiteRoleDisplayConfiguration_Site 
FOREIGN KEY(SiteId)
REFERENCES dbo.Site (Id)

GO

ALTER TABLE dbo.SiteRoleDisplayConfiguration
ADD CONSTRAINT FK_SiteRoleDisplayConfiguration_Role 
FOREIGN KEY(RoleId)
REFERENCES dbo.Role (Id)

GO

-- action item section
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 2, 2, null from site s, role r where r.name in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0 and s.id in (1, 2, 5, 7) 
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 2, 2, 4 from site s, role r where r.name in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0 and s.id not in (1, 2, 5, 7)
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 2, 3, null from site s, role r where r.name not in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0 and s.id in (1, 2, 5, 7)
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 2, 4, 3 from site s, role r where r.name not in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0 and s.id not in (1, 2, 5, 7)
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);

-- lab alert section
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 3, 5, null from site s, role r where r.name = 'Restriction Reporting Admin' and r.deleted = 0
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 3, 6, null from site s, role r where r.name != 'Restriction Reporting Admin' and r.deleted = 0
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);

-- log section
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 4, 10, 8 from site s, role r where r.name in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0 and s.id in (3)
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 4, 7, null from site s, role r where r.name in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0 and s.id in (1, 2, 5, 7)
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 4, 8, 7 from site s, role r where r.name in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0 and s.id not in (3) and s.id not in (1, 2, 5, 7)
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id); 
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 4, 7, null from site s, role r where r.name not in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0 and s.id in (1, 2, 5, 7)
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 4, 8, 7 from site s, role r where r.name not in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0 and s.id not in (1, 2, 5, 7)
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);

-- restriction section
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 5, 15, null from site s, role r where r.name = 'Restriction Reporting Admin' and r.deleted = 0
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 5, 16, null from site s, role r where r.name != 'Restriction Reporting Admin' and r.deleted = 0
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);

-- shift handover section
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 6, 18, 17 from site s, role r where r.deleted = 0
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);

-- target section
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 7, 19, null from site s, role r where r.name in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);
insert into SiteRoleDisplayConfiguration select s.Id, r.Id, 7, 20, null from site s, role r where r.name not in ('Supervisor', 'Supervisor Plus', 'TA Manager', 'TA Director') and r.deleted = 0
	and exists(select t.roleid from RoleElementTemplate t where t.RoleId = r.Id and t.SiteId = s.Id);


--select b.name, c.name, a.sectionid, a.primarydefaultpageid, secondarydefaultpageid
--from SiteRoleDisplayConfiguration a,
--Site b,
--Role c
--where a.siteid = b.id
--and a.roleid = c.id
--order by 1, 2, 3


GO
