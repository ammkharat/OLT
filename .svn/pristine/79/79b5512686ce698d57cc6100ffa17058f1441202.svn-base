insert into roleelement
values (121, 'View Marked As Read Report')


insert into roleelementtemplate
(roleelementid, roleid, siteid)
select 121, 1, id
from site
where exists
(
	select *
	from roleelementtemplate
	where roleid = 1
	and siteid = id
)

insert into roleelementtemplate
(roleelementid, roleid, siteid)
select 121, 12, id
from site
where exists
(
	select *
	from roleelementtemplate
	where roleid = 12
	and siteid = id
)

insert into roleelementtemplate
(roleelementid, roleid, siteid)
select 121, 39, id
from site
where exists
(
	select *
	from roleelementtemplate
	where roleid = 39
	and siteid = id
)


go

GO
