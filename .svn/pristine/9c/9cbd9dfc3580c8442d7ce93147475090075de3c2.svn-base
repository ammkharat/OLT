--select *
--from FunctionalLocation
--where Id in (112880, 112882, 112885, 112906, 112877, 112904, 112917)


--select b.fullhierarchy, b.deleted, c.fullhierarchy, c.deleted
--from FunctionalLocationAncestor a,
--FunctionalLocation b,
--FunctionalLocation c
--where a.id = c.id
--and a.ancestorid = b.id
--and b.deleted != c.deleted
--and b.siteid = 7
--order by b.fullhierarchy, c.fullhierarchy

--159710	MR1-MOBL	0
--112877	MR1-MOBL	1
--159711	MR1-MOBL-FORK	0
--112880	MR1-MOBL-FORK	1
--159712	MR1-MOBL-LVFM	0
--112882	MR1-MOBL-LVFM	1
--159713	MR1-MOBL-SUPM	0
--112885	MR1-MOBL-SUPM	1
--159722	MR1-P001	0
--112904	MR1-P001	1
--160270	MR1-P001-IFST	0
--112906	MR1-P001-IFST	1
--161039	MR1-P004	0
--112917	MR1-P004	1

delete from FunctionalLocationAncestor where exists (select Id from FunctionalLocation where FunctionalLocation.Id = FunctionalLocationAncestor.Id and SiteId = 7);

go

-- 8 rows
update FunctionalLocation
set ParentId = 159710
where ParentId = 112877
and exists(select Id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-MOBL' and id = 159710 and deleted = 0)
and exists(select Id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-MOBL' and id = 112877 and deleted = 1);
-- 12 rows
update FunctionalLocation
set ParentId = 159722
where ParentId = 112904
and exists(select Id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-P001' and id = 159722 and deleted = 0)
and exists(select Id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-P001' and id = 112904 and deleted = 1);
-- 1 row
update FunctionalLocation
set ParentId = 161039
where ParentId = 112917
and exists(select Id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-P004' and id = 161039 and deleted = 0)
and exists(select Id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-P004' and id = 112917 and deleted = 1);

go

delete from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-MOBL' and id = 112877 and deleted = 1;
delete from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-P001' and id = 112904 and deleted = 1;
delete from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-P004' and id = 112917 and deleted = 1;

go


delete from FunctionalLocationOperationalMode
where UnitId = (select id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-MOBL-FORK' and id = 112880 and deleted = 1);
delete from FunctionalLocationOperationalMode
where UnitId = (select id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-MOBL-LVFM' and id = 112882 and deleted = 1);
delete from FunctionalLocationOperationalMode
where UnitId = (select id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-MOBL-SUPM' and id = 112885 and deleted = 1);
delete from FunctionalLocationOperationalMode
where UnitId = (select id from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-P001-IFST' and id = 112906 and deleted = 1);

go

delete from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-MOBL-FORK' and id = 112880 and deleted = 1;
delete from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-MOBL-LVFM' and id = 112882 and deleted = 1;
delete from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-MOBL-SUPM' and id = 112885 and deleted = 1;
delete from FunctionalLocation where siteid = 7 and FullHierarchy = 'MR1-P001-IFST' and id = 112906 and deleted = 1;

go

insert into FunctionalLocationAncestor (Id, AncestorId)
select c.id, a.id 
from FunctionalLocation c,
functionallocation a
where c.siteid = 7
and a.siteid = c.siteid
and c.level > 1
and a.level < c.level
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
;

go

alter table FunctionalLocation
add CONSTRAINT FunctionalLocation_Unique_SiteId_FullHierarchy UNIQUE NONCLUSTERED
(
	SiteId ASC,
	FullHierarchy ASC
)
;

go

GO
