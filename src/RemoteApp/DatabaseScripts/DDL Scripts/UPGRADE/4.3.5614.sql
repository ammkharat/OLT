

INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id,
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 5 and r.Name = 'Administrator'
    and re.Name in ('Configure Craft Or Trade', 'Configure Work Permit Contractor')
)



GO



update dbo.CraftOrTrade
set Deleted = 1
where SiteId = 5 and Name like '%DO NOT USE%'



GO

