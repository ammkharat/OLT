INSERT INTO RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
inner join Role r on r.Id in (select Id from Role where SiteId = 10 and Name = 'Operations Coordinator')
where re.Name in ('Approve Action Item Definition', 'Reject Action Item Definition', 'Toggle Approval Required for Action Item Definition')
go



GO

