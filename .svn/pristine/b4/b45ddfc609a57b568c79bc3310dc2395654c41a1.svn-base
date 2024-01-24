-- ----------------------------------------------------------------------------------------------------------------
-- add missing foreign key constraints
alter table TargetDefinitionReadWriteTagConfiguration with check
add constraint FK_TargetDefinitionReadWriteTagConfiguration_Max_Tag
foreign key (MaxTagId)
references Tag(Id);

alter table TargetDefinitionReadWriteTagConfiguration with check
add constraint FK_TargetDefinitionReadWriteTagConfiguration_Min_Tag
foreign key (MinTagId)
references Tag(Id);

alter table TargetDefinitionReadWriteTagConfiguration with check
add constraint FK_TargetDefinitionReadWriteTagConfiguration_Target_Tag
foreign key (TargetTagId)
references Tag(Id);

alter table TargetDefinitionReadWriteTagConfiguration with check
add constraint FK_TargetDefinitionReadWriteTagConfiguration_GapUnitValue_Tag
foreign key (GapUnitValueTagId)
references Tag(Id);

ALTER TABLE TagGroupAssociation WITH CHECK CHECK CONSTRAINT FK_TagGroupAssociation_Tag;


-- ----------------------------------------------------------------------------------------------------------------
-- add temporary foreign key constraints
alter table RestrictionDefinitionHistory with check
add constraint FK_RestrictionDefinitionHistory_Measurement_Tag
foreign key (MeasurementTagID)
references Tag(Id);

alter table RestrictionDefinitionHistory with check
add constraint FK_RestrictionDefinitionHistory_ProductionTarget_Tag
foreign key (ProductionTargetTagID)
references Tag(Id);

alter table TargetDefinitionHistory with check
add constraint FK_RTargetDefinitionHistory_Tag
foreign key (TagId)
references Tag(Id);


-- ----------------------------------------------------------------------------------------------------------------
-- This tag has duplicates and all duplicate for it are used.
-- Remove the reference to one of the duplicates of:
--     93454	04REFORMATE_RVPSTG.LAB	2	1	196884	04REFORMATE_RVPSTG.LAB	2	1
-- We choose to delete 93454 because it is on a target definition that is already deleted.

-- 168 rows
update TargetAlert 
set TagID = 196884 
where TagID = 93454
and exists (select Id from tag where name = '04REFORMATE_RVPSTG.LAB' and id = 196884)
and exists (select Id from tag where name = '04REFORMATE_RVPSTG.LAB' and id = 93454);

-- 1 row
update TargetDefinition 
set TagID = 196884 
where TagID = 93454
and exists (select Id from tag where name = '04REFORMATE_RVPSTG.LAB' and id = 196884)
and exists (select Id from tag where name = '04REFORMATE_RVPSTG.LAB' and id = 93454);

-- 50 rows
update TargetDefinitionHistory 
set TagID = 196884 
where TagID = 93454
and exists (select Id from tag where name = '04REFORMATE_RVPSTG.LAB' and id = 196884)
and exists (select Id from tag where name = '04REFORMATE_RVPSTG.LAB' and id = 93454);

delete from Tag
where Id = 93454
and name = '04REFORMATE_RVPSTG.LAB'
and not
				(
					exists(select x.Id from DeviationAlert x where MeasurementValueTagId = tag.Id) or
					exists(select x.Id from DeviationAlert x where ProductionTargetValueTagId = tag.Id) or
					exists(select x.Id from RestrictionDefinition x where MeasurementTagID = tag.Id) or
					exists(select x.Id from RestrictionDefinition x where ProductionTargetTagID = tag.Id) or
					exists(select x.Id from RestrictionDefinitionHistory x where MeasurementTagID = tag.Id) or
					exists(select x.Id from RestrictionDefinitionHistory x where ProductionTargetTagID = tag.Id) or
					exists(select x.TagGroupId from TagGroupAssociation x where TagId = tag.Id) or
					exists(select x.Id from TargetAlert x where TagID = tag.Id) or
					exists(select x.Id from TargetDefinition x where TagID = tag.Id) or
					exists(select x.Id from TargetDefinitionHistory x where TagID = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where TargetTagId = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MinTagId = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MaxTagId = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where GapUnitValueTagId = tag.Id) 
				)
;

go

-- ----------------------------------------------------------------------------------------------------------------
-- delete the duplicate tags marked as deleted, should be 16
delete from tag
where id in
(
	select id
	from
	(
		select t.Id, t.Name, t.SiteId
		from tag t,
		(
			select siteid, name, count(*) duplicate_count
			from tag
			where  1=1
			--and deleted = 0
			group by siteid, name
			having count(*) > 1
		) b
		where t.siteid = b.siteid
		and t.name = b.name
		and t.deleted = 1
		--order by t.name, t.id
	) DuplicatesMarkedAsDeleted
);

go


-- ----------------------------------------------------------------------------------------------------------------
-- remove duplicates where duplicate count = 3
-- 92117	02FC104.PV	TOTAL GAS OIL
-- 196746	02FC104.PV	TOTAL GAS OIL         <- delete
-- 196747	02FC104.PV	TOTAL GAS OIL
-- 95322	08TI1060.HA	Tank T-60 Temp 1HR AV
-- 196949	08TI1060.HA	Tank T-60 Temp 1HR AV <- delete
-- 196950	08TI1060.HA	Tank T-60 Temp 1HR AV

delete from Tag
where Id = 196746
and name = '02FC104.PV'
and not
				(
					exists(select x.Id from DeviationAlert x where MeasurementValueTagId = tag.Id) or
					exists(select x.Id from DeviationAlert x where ProductionTargetValueTagId = tag.Id) or
					exists(select x.Id from RestrictionDefinition x where MeasurementTagID = tag.Id) or
					exists(select x.Id from RestrictionDefinition x where ProductionTargetTagID = tag.Id) or
					exists(select x.Id from RestrictionDefinitionHistory x where MeasurementTagID = tag.Id) or
					exists(select x.Id from RestrictionDefinitionHistory x where ProductionTargetTagID = tag.Id) or
					exists(select x.TagGroupId from TagGroupAssociation x where TagId = tag.Id) or
					exists(select x.Id from TargetAlert x where TagID = tag.Id) or
					exists(select x.Id from TargetDefinition x where TagID = tag.Id) or
					exists(select x.Id from TargetDefinitionHistory x where TagID = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where TargetTagId = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MinTagId = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MaxTagId = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where GapUnitValueTagId = tag.Id) 
				)
;


delete from Tag
where Id = 196949
and name = '08TI1060.HA'
and not
				(
					exists(select x.Id from DeviationAlert x where MeasurementValueTagId = tag.Id) or
					exists(select x.Id from DeviationAlert x where ProductionTargetValueTagId = tag.Id) or
					exists(select x.Id from RestrictionDefinition x where MeasurementTagID = tag.Id) or
					exists(select x.Id from RestrictionDefinition x where ProductionTargetTagID = tag.Id) or
					exists(select x.Id from RestrictionDefinitionHistory x where MeasurementTagID = tag.Id) or
					exists(select x.Id from RestrictionDefinitionHistory x where ProductionTargetTagID = tag.Id) or
					exists(select x.TagGroupId from TagGroupAssociation x where TagId = tag.Id) or
					exists(select x.Id from TargetAlert x where TagID = tag.Id) or
					exists(select x.Id from TargetDefinition x where TagID = tag.Id) or
					exists(select x.Id from TargetDefinitionHistory x where TagID = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where TargetTagId = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MinTagId = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MaxTagId = tag.Id) or
					exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where GapUnitValueTagId = tag.Id) 
				)
;

go


-- ----------------------------------------------------------------------------------------------------------------
-- remove the half of the duplicate that is not used
-- favour max tag because most of them are not used

delete 
from tag 
where Id in
(
	select TagIdToDelete =
      CASE 
         WHEN (MaxTagIsUsed is null) THEN MaxTagId 
         WHEN (MinTagIsUsed is null) THEN MinTagId
      END
	from
	(
		select 
			DuplicateTagWithMinIdView.Id as MinTagId,
			DuplicateTagWithMinIdView.Name as MinTagName,
			DuplicateTagWithMinIdView.SiteId as MinTagSiteId, 
			DuplicateTagWithMinIdView.IsUsed as MinTagIsUsed,
			DuplicateTagWithMaxIdView.Id as MaxTagId, 
			DuplicateTagWithMaxIdView.Name as MaxTagName, 
			DuplicateTagWithMaxIdView.SiteId as MaxTagSiteId, 
			DuplicateTagWithMaxIdView.IsUsed as MaxTagIsUsed
		from
		(
			select t.Id, t.Name, t.SiteId, TagUsageView.IsUsed
			from tag t
			join
			(
				select min(id) as Id
				from
				(
					select a.Id, a.Name, a.SiteId
					from tag a,
					(
						select siteid, name, count(*) duplicate_count
						from tag
						where  1=1
						and deleted = 0
						group by siteid, name
						having count(*) > 1
					) b
					where a.siteid = b.siteid
					and a.name = b.name
					and deleted = 0
					--order by a.name, a.id
				) duplicates
				group by siteid, name
			) minId on t.Id = minId.Id
			left join 
			(select tag.Id as id, 1 as IsUsed from tag where tag.deleted = 0 
						and
						(
							exists(select x.Id from DeviationAlert x where MeasurementValueTagId = tag.Id) or
							exists(select x.Id from DeviationAlert x where ProductionTargetValueTagId = tag.Id) or
							exists(select x.Id from RestrictionDefinition x where MeasurementTagID = tag.Id) or
							exists(select x.Id from RestrictionDefinition x where ProductionTargetTagID = tag.Id) or
							exists(select x.Id from RestrictionDefinitionHistory x where MeasurementTagID = tag.Id) or
							exists(select x.Id from RestrictionDefinitionHistory x where ProductionTargetTagID = tag.Id) or
							exists(select x.TagGroupId from TagGroupAssociation x where TagId = tag.Id) or
							exists(select x.Id from TargetAlert x where TagID = tag.Id) or
							exists(select x.Id from TargetDefinition x where TagID = tag.Id) or
							exists(select x.Id from TargetDefinitionHistory x where TagID = tag.Id) or
							exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where TargetTagId = tag.Id) or
							exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MinTagId = tag.Id) or
							exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MaxTagId = tag.Id) or
							exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where GapUnitValueTagId = tag.Id) 
						)
			) TagUsageView on TagUsageView.id = t.id
		) DuplicateTagWithMinIdView,
		(
			select t.Id, t.Name, t.SiteId, TagUsageView.IsUsed
			from tag t
			join 
			(
				select max(id) as Id
				from
				(
					select a.Id, a.Name, a.SiteId
					from tag a,
					(
						select siteid, name, count(*) duplicate_count
						from tag
						where  1=1
						and deleted = 0
						group by siteid, name
						having count(*) > 1
					) b
					where a.siteid = b.siteid
					and a.name = b.name
					and deleted = 0
					--order by a.name, a.id
				) duplicates
				group by siteid, name
			) minId on t.Id = minId.Id
			left join 
			(select tag.Id as id, 1 as IsUsed from tag where tag.deleted = 0 
						and
						(
							exists(select x.Id from DeviationAlert x where MeasurementValueTagId = tag.Id) or
							exists(select x.Id from DeviationAlert x where ProductionTargetValueTagId = tag.Id) or
							exists(select x.Id from RestrictionDefinition x where MeasurementTagID = tag.Id) or
							exists(select x.Id from RestrictionDefinition x where ProductionTargetTagID = tag.Id) or
							exists(select x.Id from RestrictionDefinitionHistory x where MeasurementTagID = tag.Id) or
							exists(select x.Id from RestrictionDefinitionHistory x where ProductionTargetTagID = tag.Id) or
							exists(select x.TagGroupId from TagGroupAssociation x where TagId = tag.Id) or
							exists(select x.Id from TargetAlert x where TagID = tag.Id) or
							exists(select x.Id from TargetDefinition x where TagID = tag.Id) or
							exists(select x.Id from TargetDefinitionHistory x where TagID = tag.Id) or
							exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where TargetTagId = tag.Id) or
							exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MinTagId = tag.Id) or
							exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where MaxTagId = tag.Id) or
							exists(select x.Id from TargetDefinitionReadWriteTagConfiguration x where GapUnitValueTagId = tag.Id) 
						)
			) TagUsageView on TagUsageView.id = t.id
		) DuplicateTagWithMaxIdView
		where DuplicateTagWithMinIdView.Name = DuplicateTagWithMaxIdView.Name
		and DuplicateTagWithMinIdView.SiteId = DuplicateTagWithMaxIdView.SiteId
	) IDToDeleteView
)
;

go


-- ----------------------------------------------------------------------------------------------------------------
-- delete temporary foreign key constraints
alter table RestrictionDefinitionHistory
drop constraint FK_RestrictionDefinitionHistory_Measurement_Tag;

alter table RestrictionDefinitionHistory
drop constraint FK_RestrictionDefinitionHistory_ProductionTarget_Tag

alter table TargetDefinitionHistory
drop constraint FK_RTargetDefinitionHistory_Tag

go
