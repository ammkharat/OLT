declare @roleId bigint

select @roleId = id from [role] where siteid = 3 and [name] = 'Administrator'

INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  select id, @roleId
  from dbo.RoleElement where [name] like 'View Target%'
)

GO
