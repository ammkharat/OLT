insert into roleelementtemplate (roleelementid, roleid, siteid)
select a.roleelementid, a.roleid, 8
from roleelementtemplate a
where siteid = 3
and roleelementid not in 
(
	47, 48, -- sap notification
	100,101,102,103,104,105,106,107,108,109,110,128, -- restriction
	130,131,132,133,134 -- lab alert
)
and roleid not in ( 41, 42, 43, 44, 45)

go
GO

