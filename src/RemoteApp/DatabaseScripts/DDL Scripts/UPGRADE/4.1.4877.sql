delete
from roleelementtemplate
where roleelementid = 127
and roleid not in (select id from role where siteid = 3)


go


GO
