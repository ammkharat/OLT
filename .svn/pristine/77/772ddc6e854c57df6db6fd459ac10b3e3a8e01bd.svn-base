/*
select a.id, a.name, a.siteid, c.fullhierarchy
from businesscategory a
left join businesscategoryflocassociation b on a.id = b.businesscategoryid
left join functionallocation c on b.functionallocationid = c.id
order by a.id

select a.name, c.name, c.siteid, d.fullhierarchy, d.siteid
from actionitemdefinition a,
actionitemdefinitionfunctionallocation b,
businesscategory c,
functionallocation d
where a.id = b.actionitemdefinitionid
and a.businesscategoryid = c.id
and b.functionallocationid = d.id
and c.siteid != d.siteid

select a.name, c.name, c.siteid, d.fullhierarchy, d.siteid
from actionitem a,
actionitemfunctionallocation b,
businesscategory c,
functionallocation d
where a.id = b.actionitemid
and a.businesscategoryid = c.id
and b.functionallocationid = d.id
and c.siteid != d.siteid


*/

alter table BusinessCategory 
add SiteId bigint null;

go

insert into BusinessCategory
(	
	Name, 
	ShortName, 
	issapworkorderdefault, 
	issapnotificationdefault, 
	lastmodifieduserid, 
	lastmodifieddatetime, 
	createddatetime,
	deleted,
	SiteId
)
select 
	bc.name, 
	bc.shortname, 
	bc.issapworkorderdefault, 
	bc.issapnotificationdefault, 
	bc.lastmodifieduserid, 
	bc.lastmodifieddatetime, 
	bc.createddatetime,
	bc.deleted,
	BusinessCategorySite.SiteId
from BusinessCategory bc,
(
	select distinct b.Id as BusinessCategoryId, f.SiteId as SiteId
	from BusinessCategory b,
	BusinessCategoryFLOCAssociation bf,
	FunctionalLocation f
	where b.id = bf.BusinessCategoryId
	and bf.FunctionalLocationId = f.id
) BusinessCategorySite
where bc.Id = BusinessCategorySite.BusinessCategoryId
;

go

UPDATE a
SET a.BusinessCategoryId = new.Id
--select a.businesscategoryid, new.id
FROM ActionItemDefinition a	 
     join ActionItemDefinitionFunctionalLocation af on a.Id = af.ActionItemDefinitionId
     join FunctionalLocation f on af.FunctionalLocationId = f.Id
     join BusinessCategory old on a.BusinessCategoryId = old.Id
     join BusinessCategory new on 
		old.Id != new.id
		and old.name = new.name
		and new.SiteId = f.SiteId
;

UPDATE h
SET h.BusinessCategoryId = new.Id
--select a.businesscategoryid, new.id
FROM ActionItemDefinitionHistory h
     join ActionItemDefinitionFunctionalLocation af on h.Id = af.ActionItemDefinitionId
     join FunctionalLocation f on af.FunctionalLocationId = f.Id
     join BusinessCategory old on h.BusinessCategoryId = old.Id
     join BusinessCategory new on 
		old.Id != new.id
		and old.name = new.name
		and new.SiteId = f.SiteId
;

UPDATE a
SET a.BusinessCategoryId = new.Id
--select a.businesscategoryid, new.id
FROM ActionItem a
     join ActionItemFunctionalLocation af on a.Id = af.ActionItemId
     join FunctionalLocation f on af.FunctionalLocationId = f.Id
     join BusinessCategory old on a.BusinessCategoryId = old.Id
     join BusinessCategory new on 
		old.Id != new.id
		and old.name = new.name
		and new.SiteId = f.SiteId
;


-- do this last, after the action items have been updated 
UPDATE bf
SET bf.BusinessCategoryId = new.Id
FROM BusinessCategoryFlocAssociation bf
     join BusinessCategory old on bf.BusinessCategoryId = old.Id
	 join FunctionalLocation f on f.Id = bf.FunctionalLocationId
     join BusinessCategory new on 
		old.Id != new.id
		and old.name = new.name
		and new.SiteId = f.SiteId
;



delete from BusinessCategory where SiteId is null;

go


alter table BusinessCategory
alter column siteId bigint not null;

ALTER TABLE BusinessCategory WITH CHECK 
ADD CONSTRAINT FK_BusinessCategory_Site FOREIGN KEY(SiteId)
REFERENCES Site (Id);

go

GO
