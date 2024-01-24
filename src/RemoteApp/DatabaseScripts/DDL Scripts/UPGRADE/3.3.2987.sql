insert into roleelement values (135, 'Configure Lab Alert');

GO

insert into roleelementtemplate
select distinct 135, roleid, siteid
from roleelementtemplate
where roleid = 37
and siteid = 3;

GO

alter table SiteConfiguration
add LabAlertRetryAttemptLimit int null;
 
GO

update SiteConfiguration
set LabAlertRetryAttemptLimit = 3;

GO

alter table SiteConfiguration
alter column LabAlertRetryAttemptLimit int not null;

GO




GO
