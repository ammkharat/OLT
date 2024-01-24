alter table Role
add SiteId bigint null;

alter table Role
add WarnIfWorkAssignmentNotSelected bit null;

alter table Role
add OldRoleId bigint null;

go

alter table Role
ADD CONSTRAINT FK_Role_Site
FOREIGN KEY(SiteId)
REFERENCES Site (Id);

go

insert into Role
(SiteId, Name, RoleGroupId, ActiveDirectoryKey, Deleted, OldRoleId, WarnIfWorkAssignmentNotSelected, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole)
select distinct a.SiteId, b.Name, b.RoleGroupId, b.ActiveDirectoryKey, b.Deleted, b.Id, 0, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole
from RoleElementTemplate a,
Role b
where a.RoleId = b.Id;

go

-- -------------------------------------------------------------

update r
set r.WarnIfWorkAssignmentNotSelected = c.WarnIfWorkAssignmentNotSelected
from SiteRoleConfiguration c
join Role r on r.SiteId = c.SiteId and r.OldRoleId = c.RoleId;

go

drop table SiteRoleConfiguration;

go

-- -------------------------------------------------------------

ALTER TABLE RoleElementTemplate 
drop RET_UNIQUE;

go

drop index IDX_ROLEELEMENTTEMPLATE_ROLE_SITE on RoleElementTemplate

go

update t
set t.RoleId = r.Id
from Role r
join RoleElementTemplate t on r.OldRoleId = t.RoleId and r.SiteId = t.SiteId;

go

alter table RoleElementTemplate
drop column SiteId;

go

ALTER TABLE RoleElementTemplate 
ADD CONSTRAINT UK_RoleElementTemplate UNIQUE NONCLUSTERED 
(
	RoleElementId ASC,
	RoleId ASC
);

go

CREATE CLUSTERED INDEX IDX_ROLEELEMENTTEMPLATE_ROLE ON RoleElementTemplate
(
	RoleId ASC
);

go


-- -------------------------------------------------------------

alter table SiteRoleDisplayConfiguration
drop FK_SiteRoleDisplayConfiguration_Site;

go

alter table SiteRoleDisplayConfiguration
drop UQ_SiteRoleDisplayConfiguration;

go

update c
set c.RoleId = r.Id
from Role r
join SiteRoleDisplayConfiguration c on r.OldRoleId = c.RoleId and r.SiteId = c.SiteId;

go

alter table SiteRoleDisplayConfiguration
drop column SiteId;

go

ALTER TABLE SiteRoleDisplayConfiguration
ADD CONSTRAINT UQ_RoleDisplayConfiguration UNIQUE NONCLUSTERED 
(
	[RoleId] ASC,
	[SectionId] ASC
);

go

-- -------------------------------------------------------------

update w
set w.RoleId = r.Id
from Role r
join WorkAssignment w on r.OldRoleId = w.RoleId and r.SiteId = w.SiteId;

go

ALTER TABLE WorkAssignment
ADD CONSTRAINT FK_WorkAssignment_Site
FOREIGN KEY (SiteId)
REFERENCES Site (Id)

go


-- -------------------------------------------------------------

delete from Role
where SiteId is null;

go

alter table Role
alter column SiteId bigint not null;

go

alter table Role
alter column WarnIfWorkAssignmentNotSelected bit not null;

go

alter table Role
alter column ActiveDirectoryKey varchar(255) not null;

go

alter table Role
drop column OldRoleId;

go



GO
