-- ----------------------------------------------------------------------------------------------------------------
-- This tag has duplicates and all duplicate for it are used.
-- Remove the reference to one of the duplicates of:
--    99137	16FC26.HA	FEED P-775 DISCH 1HR AV	BPD	2	0
--    197470	16FC26.HA	FEED P-775 DISCH 1HR AV	BPD	2	0
-- We choose to delete 99137 because it is on a target definition that is already deleted.

-- 265
update TargetAlert 
set TagID = 197470 
where TagID = 99137
and exists (select Id from tag where name = '16FC26.HA' and id = 197470)
and exists (select Id from tag where name = '16FC26.HA' and id = 99137);

-- 2
update TargetDefinition 
set TagID = 197470 
where TagID = 99137
and exists (select Id from tag where name = '16FC26.HA' and id = 197470)
and exists (select Id from tag where name = '16FC26.HA' and id = 99137);

-- 315
update TargetDefinitionHistory 
set TagID = 197470 
where TagID = 99137
and exists (select Id from tag where name = '16FC26.HA' and id = 197470)
and exists (select Id from tag where name = '16FC26.HA' and id = 99137);

delete from Tag
where Id = 99137
and name = '16FC26.HA'
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
delete from Tag
where Id = 102229
and name = '19FC305HA.PTARGET'
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



GO
