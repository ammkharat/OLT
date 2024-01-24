

/* apply the daily directive roleelements (96-99) which currently only belong to site 5 (firebag) to site 3 (oilsands) */
insert into roleelementtemplate (roleelementid, roleid, siteid)
select ret.roleelementid, ret.roleid, 3
from roleelementtemplate ret
where roleelementid in (96, 97, 98, 99);

GO
