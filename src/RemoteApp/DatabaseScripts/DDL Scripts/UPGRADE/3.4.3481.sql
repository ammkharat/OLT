update workassignment
set UseForWorkPermitAutoAssignment = 1
where siteid = 1
and deleted = 0
and roleid = 2
and name in ('EB', 'EC', 'GD', 'GF', 'GH', 'GR', 'GS', 'TB', 'TC', 'TD', 'TE', 'TL', 'WB', 'WD', 'XB', 'XC', 'XD');

go


GO
