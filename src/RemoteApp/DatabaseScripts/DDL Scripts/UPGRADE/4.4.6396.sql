

INSERT INTO RoleElementTemplate (RoleElementId, RoleId)    
select re.Id, r.Id    
from RoleElement re    
left outer join Role r on r.Id in (select Id from Role where SiteId = 8 and Name = 'Administrator')
where re.Name in ('Import Permit Requests')

go  


GO

