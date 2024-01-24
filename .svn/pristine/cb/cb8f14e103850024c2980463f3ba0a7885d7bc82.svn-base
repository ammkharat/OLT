DECLARE @UnitLevelFloc1 AS BIGINT;
select @UnitLevelFloc1 = id from functionallocation where fullhierarchy = 'SR1-PLT3-BDP3';

DECLARE @UnitLevelFloc2 AS BIGINT;
select @UnitLevelFloc2 = id from functionallocation where fullhierarchy = 'SR1-PLT3-ELP3';

DECLARE @UnitLevelFloc3 AS BIGINT;
select @UnitLevelFloc3 = id from functionallocation where fullhierarchy = 'SR1-PLT3-FSP3';


SET IDENTITY_INSERT DeviationAlert ON

insert into DeviationAlert(
id,
DeviationAlertResponseId,
RestrictionDefinitionId,
RestrictionDefinitionName,
RestrictionDefinitionDescription,
productiontargetvalue, 
measurementvalue, 
startdatetime, 
enddatetime,
lastmodifieduserid, 
lastmodifieddatetime, 
createddatetime,
FunctionalLocationId,
MeasurementValueTagId,
ProductionTargetValueTagId,
Comments)
values (1,1, 1, 'Test Dev. Alert 1', 'Test Def. Desc. 1', 100, 50, {ts '2010-01-15 10:15:32'}, {ts '2010-02-15 10:15:32'}, 1, {ts '2010-09-15 10:15:32'}, {ts '2010-10-15 10:15:32'}, @UnitLevelFloc1, 1, 2, 'comments');

insert into DeviationAlert(
id,
RestrictionDefinitionId,
RestrictionDefinitionName,
RestrictionDefinitionDescription,
productiontargetvalue, 
measurementvalue, 
startdatetime, 
enddatetime,
lastmodifieduserid, 
lastmodifieddatetime, 
createddatetime,
FunctionalLocationId,
MeasurementValueTagId,
ProductionTargetValueTagId)
values (2, 1, 'Test Dev. Alert 2', 'Test Def Desc. 2', 11.2, 22.3, {ts '2010-03-15 10:15:32'}, {ts '2010-04-15 10:15:32'}, 1, GetDate(), {ts '2010-05-18 14:19:07'}, @UnitLevelFloc2, 1, 2);

insert into DeviationAlert(
id,
RestrictionDefinitionId,
RestrictionDefinitionName,
productiontargetvalue, 
measurementvalue, 
startdatetime, 
enddatetime,
lastmodifieduserid, 
lastmodifieddatetime, 
createddatetime,
FunctionalLocationId,
MeasurementValueTagId,
ProductionTargetValueTagId)
values (3, 1, 'Test Dev. Alert 3', null, null, {ts '2010-05-15 10:15:32'}, GetDate(), 1, GetDate(), {ts '2010-05-18 14:21:32'}, @UnitLevelFloc3, 1, null);

SET IDENTITY_INSERT DeviationAlert OFF
