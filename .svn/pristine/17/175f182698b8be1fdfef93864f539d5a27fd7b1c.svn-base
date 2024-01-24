DECLARE @SCHEDULE_ID BIGINT;
DECLARE @SITE_ID BIGINT
SET @SITE_ID = 3;
DECLARE @RECURRING_DAILY_ID BIGINT;
SET @RECURRING_DAILY_ID = 3;

DECLARE @WORK_ASSIGNMENT_ID AS BIGINT;
select @WORK_ASSIGNMENT_ID = min(id)
from workassignment
where siteid = 3
and deleted = 0
and upper(name) like '%UP2%PRIMARY%UNIT%LEADER'  

DECLARE @FLOC_ID BIGINT;
DECLARE @NAME VARCHAR(max);
DECLARE @DESCRIPTION VARCHAR(max);

declare @PROCESS_CATEGORY bigint;
select @PROCESS_CATEGORY = id from BusinessCategory where siteid = 3 and name = 'Unit Guideline / Process';


-- ---------------------------------------------

select @FLOC_ID = Id from FunctionalLocation where FullHierarchy = 'UP2-P052-DCU2';
set @NAME = '52G-339A - Isolate&safe';
set @DESCRIPTION = '52G-339A - Mtce is replacing the GOSF line in kind. Isolate and safe.'

INSERT INTO Schedule
(LastModifiedDateTime, ScheduleTypeId, StartDateTime, EndDateTime, FromTime, ToTime, DailyFrequency, Deleted, SiteId)
VALUES
(GetDate(), @RECURRING_DAILY_ID, '2010-08-01 00:00:00.000', NULL, '08:00', '16:00', 1, 0, @SITE_ID);

INSERT INTO ActionItemDefinition
([Name], [BusinessCategoryId], [ActionItemDefinitionStatusId], [ScheduleId], [Active], [WorkAssignmentId], 
 [RequiresApproval], [ResponseRequired], [Description], [CreateAnActionItemForEachFunctionalLocation],
 [SourceId], [SapOperationId], [LastModifiedUserId], [LastModifiedDateTime], [CreatedByUserId], [CreatedDateTime], [Deleted])
VALUES
(@NAME, @PROCESS_CATEGORY, 1, IDENT_CURRENT('Schedule'), 1, @WORK_ASSIGNMENT_ID,
 0, 0, @DESCRIPTION, 1,
 0, NULL, 1, GetDate(), 1, GetDate(), 0);

INSERT INTO ActionItemDefinitionFunctionalLocation
([ActionItemDefinitionId], [FunctionalLocationId])
VALUES
(IDENT_CURRENT('ActionItemDefinition'), @FLOC_ID);


-- ---------------------------------------------

select @FLOC_ID = Id from FunctionalLocation where FullHierarchy = 'UP2-P052-DCU2';
set @NAME = '52C-399 risk review';
set @DESCRIPTION = '52C-399 Inlet Flange ELCDs - New ELCDs have arrived schedule risk review for install'

INSERT INTO Schedule
(LastModifiedDateTime, ScheduleTypeId, StartDateTime, EndDateTime, FromTime, ToTime, DailyFrequency, Deleted, SiteId)
VALUES
(GetDate(), @RECURRING_DAILY_ID, '2010-08-01 00:00:00.000', NULL, '08:00', '16:00', 1, 0, @SITE_ID);

INSERT INTO ActionItemDefinition
([Name], [BusinessCategoryId], [ActionItemDefinitionStatusId], [ScheduleId], [Active], [WorkAssignmentId],  
 [RequiresApproval], [ResponseRequired], [Description], [CreateAnActionItemForEachFunctionalLocation],
 [SourceId], [SapOperationId], [LastModifiedUserId], [LastModifiedDateTime], [CreatedByUserId], [CreatedDateTime], [Deleted])
VALUES
(@NAME, @PROCESS_CATEGORY, 1, IDENT_CURRENT('Schedule'), 1,  @WORK_ASSIGNMENT_ID,
 0, 0, @DESCRIPTION, 1,
 0, NULL, 1, GetDate(), 1, GetDate(), 0);

INSERT INTO ActionItemDefinitionFunctionalLocation
([ActionItemDefinitionId], [FunctionalLocationId])
VALUES
(IDENT_CURRENT('ActionItemDefinition'), @FLOC_ID);



-- ---------------------------------------------

select @FLOC_ID = Id from FunctionalLocation where FullHierarchy = 'UP2-P052-DCU2';
set @NAME = '52G-302A/B safe B';
set @DESCRIPTION = 'The A pump is running and has been assessed by Mtce, the mag center floating is ok and all bearings are ok. Work to safe the B pump for Mtce, scope is to change out the faulty vents/drains on suction / disch piping.'

INSERT INTO Schedule
(LastModifiedDateTime, ScheduleTypeId, StartDateTime, EndDateTime, FromTime, ToTime, DailyFrequency, Deleted, SiteId)
VALUES
(GetDate(), @RECURRING_DAILY_ID, '2010-08-01 00:00:00.000', NULL, '08:00', '16:00', 1, 0, @SITE_ID);

INSERT INTO ActionItemDefinition
([Name], [BusinessCategoryId], [ActionItemDefinitionStatusId], [ScheduleId], [Active],  [WorkAssignmentId], 
 [RequiresApproval], [ResponseRequired], [Description], [CreateAnActionItemForEachFunctionalLocation],
 [SourceId], [SapOperationId], [LastModifiedUserId], [LastModifiedDateTime], [CreatedByUserId], [CreatedDateTime], [Deleted])
VALUES
(@NAME, @PROCESS_CATEGORY, 1, IDENT_CURRENT('Schedule'), 1,  @WORK_ASSIGNMENT_ID,
 0, 0, @DESCRIPTION, 1,
 0, NULL, 1, GetDate(), 1, GetDate(), 0);

INSERT INTO ActionItemDefinitionFunctionalLocation
([ActionItemDefinitionId], [FunctionalLocationId])
VALUES
(IDENT_CURRENT('ActionItemDefinition'), @FLOC_ID);



-- ---------------------------------------------

select @FLOC_ID = Id from FunctionalLocation where FullHierarchy = 'UP2-P052-DCU2';
set @NAME = '52G-305s run B D';
set @DESCRIPTION = 'Running B and D pumps. The C is not healthy, requires a change out, replacement arrives in 2 days.'

INSERT INTO Schedule
(LastModifiedDateTime, ScheduleTypeId, StartDateTime, EndDateTime, FromTime, ToTime, DailyFrequency, Deleted, SiteId)
VALUES
(GetDate(), @RECURRING_DAILY_ID, '2010-08-01 00:00:00.000', NULL, '08:00', '16:00', 1, 0, @SITE_ID);

INSERT INTO ActionItemDefinition
([Name], [BusinessCategoryId], [ActionItemDefinitionStatusId], [ScheduleId], [Active],  [WorkAssignmentId], 
 [RequiresApproval], [ResponseRequired], [Description], [CreateAnActionItemForEachFunctionalLocation],
 [SourceId], [SapOperationId], [LastModifiedUserId], [LastModifiedDateTime], [CreatedByUserId], [CreatedDateTime], [Deleted])
VALUES
(@NAME, @PROCESS_CATEGORY, 1, IDENT_CURRENT('Schedule'), 1, @WORK_ASSIGNMENT_ID, 
 0, 0, @DESCRIPTION, 1,
 0, NULL, 1, GetDate(), 1, GetDate(), 0);

INSERT INTO ActionItemDefinitionFunctionalLocation
([ActionItemDefinitionId], [FunctionalLocationId])
VALUES
(IDENT_CURRENT('ActionItemDefinition'), @FLOC_ID);



-- ---------------------------------------------

select @FLOC_ID = Id from FunctionalLocation where FullHierarchy = 'UP2-P052-DCU2';
set @NAME = '52G-306A/B ready to go';
set @DESCRIPTION = 'The A pump was reported to have a minor seal leak, the B pump GOSF line was repaired by Mtce and is ready to go, no hot alignment needed.'

INSERT INTO Schedule
(LastModifiedDateTime, ScheduleTypeId, StartDateTime, EndDateTime, FromTime, ToTime, DailyFrequency, Deleted, SiteId)
VALUES
(GetDate(), @RECURRING_DAILY_ID, '2010-08-01 00:00:00.000', NULL, '08:00', '16:00', 1, 0, @SITE_ID);

INSERT INTO ActionItemDefinition
([Name], [BusinessCategoryId], [ActionItemDefinitionStatusId], [ScheduleId], [Active],  [WorkAssignmentId], 
 [RequiresApproval], [ResponseRequired], [Description], [CreateAnActionItemForEachFunctionalLocation],
 [SourceId], [SapOperationId], [LastModifiedUserId], [LastModifiedDateTime], [CreatedByUserId], [CreatedDateTime], [Deleted])
VALUES
(@NAME, @PROCESS_CATEGORY, 1, IDENT_CURRENT('Schedule'), 1, @WORK_ASSIGNMENT_ID, 
 0, 0, @DESCRIPTION, 1,
 0, NULL, 1, GetDate(), 1, GetDate(), 0);

INSERT INTO ActionItemDefinitionFunctionalLocation
([ActionItemDefinitionId], [FunctionalLocationId])
VALUES
(IDENT_CURRENT('ActionItemDefinition'), @FLOC_ID);



-- ---------------------------------------------

select @FLOC_ID = Id from FunctionalLocation where FullHierarchy = 'UP2-P052-DCU2';
set @NAME = '552G-300s';
set @DESCRIPTION = 'B, D - running, C and E on HSB. Ensure that Mtce is working to rotate / strap over pumps on HSB.' + CHAR(13) + CHAR(10) +
                   CHAR(13) + CHAR(10) +
                   'Work with Mtce to complete the remaining work on A, then work to place HSB.'

INSERT INTO Schedule
(LastModifiedDateTime, ScheduleTypeId, StartDateTime, EndDateTime, FromTime, ToTime, DailyFrequency, Deleted, SiteId)
VALUES
(GetDate(), @RECURRING_DAILY_ID, '2010-08-01 00:00:00.000', NULL, '08:00', '16:00', 1, 0, @SITE_ID);

INSERT INTO ActionItemDefinition
([Name], [BusinessCategoryId], [ActionItemDefinitionStatusId], [ScheduleId], [Active], [WorkAssignmentId],  
 [RequiresApproval], [ResponseRequired], [Description], [CreateAnActionItemForEachFunctionalLocation],
 [SourceId], [SapOperationId], [LastModifiedUserId], [LastModifiedDateTime], [CreatedByUserId], [CreatedDateTime], [Deleted])
VALUES
(@NAME, @PROCESS_CATEGORY, 1, IDENT_CURRENT('Schedule'), 1, @WORK_ASSIGNMENT_ID, 
 0, 0, @DESCRIPTION, 1,
 0, NULL, 1, GetDate(), 1, GetDate(), 0);

INSERT INTO ActionItemDefinitionFunctionalLocation
([ActionItemDefinitionId], [FunctionalLocationId])
VALUES
(IDENT_CURRENT('ActionItemDefinition'), @FLOC_ID);



-- ---------------------------------------------

select @FLOC_ID = Id from FunctionalLocation where FullHierarchy = 'UP2-P052-DCU2';
set @NAME = '52C-305/399 winter md';
set @DESCRIPTION = 'Operate 52C-305/399 in "winter mode", targeting DMC Kero 90% at 630-640F'

INSERT INTO Schedule
(LastModifiedDateTime, ScheduleTypeId, StartDateTime, EndDateTime, FromTime, ToTime, DailyFrequency, Deleted, SiteId)
VALUES
(GetDate(), @RECURRING_DAILY_ID, '2010-08-01 00:00:00.000', NULL, '08:00', '16:00', 1, 0, @SITE_ID);

INSERT INTO ActionItemDefinition
([Name], [BusinessCategoryId], [ActionItemDefinitionStatusId], [ScheduleId], [Active], [WorkAssignmentId],  
 [RequiresApproval], [ResponseRequired], [Description], [CreateAnActionItemForEachFunctionalLocation],
 [SourceId], [SapOperationId], [LastModifiedUserId], [LastModifiedDateTime], [CreatedByUserId], [CreatedDateTime], [Deleted])
VALUES
(@NAME, @PROCESS_CATEGORY, 1, IDENT_CURRENT('Schedule'), 1,  @WORK_ASSIGNMENT_ID,
 0, 0, @DESCRIPTION, 1,
 0, NULL, 1, GetDate(), 1, GetDate(), 0);

INSERT INTO ActionItemDefinitionFunctionalLocation
([ActionItemDefinitionId], [FunctionalLocationId])
VALUES
(IDENT_CURRENT('ActionItemDefinition'), @FLOC_ID);



-- ---------------------------------------------

select @FLOC_ID = Id from FunctionalLocation where FullHierarchy = 'UP2-P052-DCU2';
set @NAME = 'Safe 52E-310A/B';
set @DESCRIPTION = 'Work to safe 52E-310A/B and report on gas readings'

INSERT INTO Schedule
(LastModifiedDateTime, ScheduleTypeId, StartDateTime, EndDateTime, FromTime, ToTime, DailyFrequency, Deleted, SiteId)
VALUES
(GetDate(), @RECURRING_DAILY_ID, '2010-08-01 00:00:00.000', NULL, '08:00', '16:00', 1, 0, @SITE_ID);

INSERT INTO ActionItemDefinition
([Name], [BusinessCategoryId], [ActionItemDefinitionStatusId], [ScheduleId], [Active],  [WorkAssignmentId], 
 [RequiresApproval], [ResponseRequired], [Description], [CreateAnActionItemForEachFunctionalLocation],
 [SourceId], [SapOperationId], [LastModifiedUserId], [LastModifiedDateTime], [CreatedByUserId], [CreatedDateTime], [Deleted])
VALUES
(@NAME, @PROCESS_CATEGORY, 1, IDENT_CURRENT('Schedule'), 1,  @WORK_ASSIGNMENT_ID,
 0, 0, @DESCRIPTION, 1,
 0, NULL, 1, GetDate(), 1, GetDate(), 0);

INSERT INTO ActionItemDefinitionFunctionalLocation
([ActionItemDefinitionId], [FunctionalLocationId])
VALUES
(IDENT_CURRENT('ActionItemDefinition'), @FLOC_ID);


GO

