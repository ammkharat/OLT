insert into RoleElement values (154, 'Configure Coker Cards');

GO

insert into RoleElementTemplate (RoleElementId, RoleId, SiteId) values (154, 37, 3); -- Administrator

GO

alter table CokerCardConfigurationDrum drop column Deleted

GO

alter table CokerCardConfigurationCycleStep drop column Deleted



GO
