-- give the toggle approval required role element to Area Managers in Edmonton
insert into roleelementtemplate (RoleElementId, RoleId, SiteId)
values (11, 39, 8); 

GO

alter table SiteConfiguration add ActionItemRequiresApprovalDefaultValue bit null;

GO

update SiteConfiguration set ActionItemRequiresApprovalDefaultValue = 1;

GO

alter table SiteConfiguration alter column ActionItemRequiresApprovalDefaultValue bit not null

GO

update SiteConfiguration set ActionItemRequiresApprovalDefaultValue = 0 where SiteId = 8

GO

GO
