DECLARE @OPERATING_ENGINEER_GROUP BIGINT;
DECLARE @SUPERVISOR_GROUP BIGINT;

SET @OPERATING_ENGINEER_GROUP = 4;
SET @SUPERVISOR_GROUP = 2;


DECLARE @UnitLevelFloc1 AS BIGINT;
select @UnitLevelFloc1 = id from functionallocation where fullhierarchy = 'SR1-PLT3-BDP3';


DECLARE @UnitLevelFloc2 AS BIGINT;
select @UnitLevelFloc2 = id from functionallocation where fullhierarchy = 'SR1-OFFS-BDOF';

--
-- Simple individual definition log entries
--

SET IDENTITY_INSERT LogDefinition ON

-- Log Definition with Single Schedule
INSERT INTO [LogDefinition]
(
	Id,
    ScheduleId,
    CreatedDateTime,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    CreatedBy,
    Deleted,
    LastModifiedUserId,
    LastModifiedDateTime,
	CreatedByRoleId,
	PlainTextComments,
	RtfComments,
	LogType,
	CreateALogForEachFunctionalLocation,
	IsOperatingEngineerLog,
	Active
)
VALUES
(
	1,
    1,                                              -- ScheduleId,
    CONVERT(DATETIME, '2005-11-15 00:00:00', 102),  -- LoggedDate,
    0,                                              -- EHSFollowup,
    0,                                              -- ProcessControlFollowUp,
    0,                                              -- InspectionFollowUp,
    0,                                              -- OperationsFollowUp,
    0,                                              -- SupervisionFollowUp,
    0,                                              -- OtherFollowUp,
    1,                                              -- CreatedBy,
    0,                                              -- Deleted,
    1,                                              -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),  -- LastModifiedDateTime,
	71,												-- CreatedByRoleId
    'all comments',
	'all comments',
	1,
	1,
	0,
	1												-- Active
)

insert into LogDefinitionFunctionalLocation (LogDefinitionId, FunctionalLocationId)
values (1, @UnitLevelFloc1)

-- Log Definition with Continuous Schedule
INSERT INTO [LogDefinition]
(
	Id,
    ScheduleId,
    CreatedDateTime,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    CreatedBy,
    Deleted,
    LastModifiedUserId,
    LastModifiedDateTime,
	CreatedByRoleId,
	RtfComments,
	PlainTextComments,
	LogType,
	CreateALogForEachFunctionalLocation,
	IsOperatingEngineerLog,
	Active
)
VALUES
(
	2,
    3,                                              -- ScheduleId,
    CONVERT(DATETIME, '2005-11-15 00:00:00', 102),  -- CreatedDateTime,
    0,                                              -- EHSFollowup,
    0,                                              -- ProcessControlFollowUp,
    0,                                              -- InspectionFollowUp,
    0,                                              -- OperationsFollowUp,
    0,                                              -- SupervisionFollowUp,
    0,                                              -- OtherFollowUp,
    1,                                              -- CreatedBy,
    0,                                              -- Deleted,
    1,                                              -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),  -- LastModifiedDateTime,
	71,												 -- CreatedByRoleId
	'all comments',
	'all comments',
	1,
	1,
	0,
	1
)

insert into LogDefinitionFunctionalLocation (LogDefinitionId, FunctionalLocationId)
values (2, @UnitLevelFloc2)


-- Log Definition with Daily Schedule
INSERT INTO [LogDefinition]
(
	Id,
    ScheduleId,
    CreatedDateTime,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    CreatedBy,
    Deleted,
    LastModifiedUserId,
    LastModifiedDateTime,
	CreatedByRoleId,
	RtfComments,
	PlainTextComments,
	LogType,
	CreateALogForEachFunctionalLocation,
	IsOperatingEngineerLog,
	Active
)
VALUES
(
	3,
    4,                                              -- ScheduleId,
    CONVERT(DATETIME, '2005-11-15 00:00:00', 102),  -- CreatedDateTime,
    0,                                              -- EHSFollowup,
    0,                                              -- ProcessControlFollowUp,
    0,                                              -- InspectionFollowUp,
    0,                                              -- OperationsFollowUp,
    0,                                              -- SupervisionFollowUp,
    0,                                              -- OtherFollowUp,
    1,                                              -- CreatedBy,
    0,                                              -- Deleted,
    1,                                              -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),  -- LastModifiedDateTime
	53,												 -- CreatedByRoleId
	'all comments',
	'all comments',
	1,
	1,
	0,
	1
)

insert into LogDefinitionFunctionalLocation (LogDefinitionId, FunctionalLocationId)
values (3, @UnitLevelFloc2)

-- Log Definition with Weekly Schedule
INSERT INTO [LogDefinition]
(
	Id,
    ScheduleId,
    CreatedDateTime,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    CreatedBy,
    Deleted,
    LastModifiedUserId,
    LastModifiedDateTime,
	CreatedByRoleId,
	RtfComments,
	PlainTextComments,
	LogType,
	CreateALogForEachFunctionalLocation,
	IsOperatingEngineerLog,
	Active
)
VALUES
(
	4,
    5,                                              -- ScheduleId,
    CONVERT(DATETIME, '2005-11-15 00:00:00', 102),  -- CreatedDateTime,
    0,                                              -- EHSFollowup,
    0,                                              -- ProcessControlFollowUp,
    0,                                              -- InspectionFollowUp,
    0,                                              -- OperationsFollowUp,
    0,                                              -- SupervisionFollowUp,
    0,                                              -- OtherFollowUp,
    1,                                              -- CreatedBy,
    0,                                              -- Deleted,
    1,                                              -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),  -- LastModifiedDateTime
	53,												 -- CreatedByRoleId
	'all comments',
	'all comments',
	1,
	1,
	0,
	1
)

insert into LogDefinitionFunctionalLocation (LogDefinitionId, FunctionalLocationId)
values (4, @UnitLevelFloc2)

-- Log Definition with Monthlt Schedule
INSERT INTO [LogDefinition]
(
	Id,
    ScheduleId,
    CreatedDateTime,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    CreatedBy,
    Deleted,
    LastModifiedUserId,
    LastModifiedDateTime,
	CreatedByRoleId,
	RtfComments,
	PlainTextComments,
	LogType,
	CreateALogForEachFunctionalLocation,
	IsOperatingEngineerLog,
	Active
)
VALUES
(
	5,
    6,                                              -- ScheduleId,
    CONVERT(DATETIME, '2005-11-15 00:00:00', 102),  -- CreatedDateTime,
    0,                                              -- EHSFollowup,
    0,                                              -- ProcessControlFollowUp,
    0,                                              -- InspectionFollowUp,
    0,                                              -- OperationsFollowUp,
    0,                                              -- SupervisionFollowUp,
    0,                                              -- OtherFollowUp,
    1,                                              -- CreatedBy,
    0,                                              -- Deleted,
    1,                                              -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),  -- LastModifiedDateTime,
	53,												 -- CreatedByRoleId
	'all comments',
	'all comments',
	1,
	1,
	0,
	1
)

insert into LogDefinitionFunctionalLocation (LogDefinitionId, FunctionalLocationId)
values (5, @UnitLevelFloc2)

-- Log Definition with Recurring Daily Schedule
INSERT INTO [LogDefinition]
(
	Id,
    ScheduleId,
    CreatedDateTime,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    CreatedBy,
    Deleted,
    LastModifiedUserId,
    LastModifiedDateTime,
	CreatedByRoleId,
	RtfComments,
	PlainTextComments,
	LogType	,
	CreateALogForEachFunctionalLocation,
	IsOperatingEngineerLog,
	Active
)
VALUES
(
	6,
    8,                                              -- ScheduleId,
    CONVERT(DATETIME, '2005-11-15 00:00:00', 102),  -- CreatedDateTime,
    0,                                              -- EHSFollowup,
    0,                                              -- ProcessControlFollowUp,
    0,                                              -- InspectionFollowUp,
    0,                                              -- OperationsFollowUp,
    0,                                              -- SupervisionFollowUp,
    0,                                              -- OtherFollowUp,
    1,                                              -- CreatedBy,
    0,                                              -- Deleted,
    1,                                              -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),  -- LastModifiedDateTime
	53,												 -- CreatedByRoleId
	'all comments',
	'all comments',
	1,
	1,
	0,
	1
)

insert into LogDefinitionFunctionalLocation (LogDefinitionId, FunctionalLocationId)
values (6, @UnitLevelFloc2)


-- Log Definition with Recurring Daily Schedule
INSERT INTO [LogDefinition]
(
	Id,
    ScheduleId,
    CreatedDateTime,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    CreatedBy,
    Deleted,
    LastModifiedUserId,
    LastModifiedDateTime,
	CreatedByRoleId,
	RtfComments,
	PlainTextComments,
	LogType,
	CreateALogForEachFunctionalLocation,
	IsOperatingEngineerLog,
	Active
)
VALUES
(
	7,
    10,                                             -- ScheduleId,
    CONVERT(DATETIME, '2005-11-15 00:00:00', 102),  -- CreatedDateTime,
    0,                                              -- EHSFollowup,
    0,                                              -- ProcessControlFollowUp,
    0,                                              -- InspectionFollowUp,
    0,                                              -- OperationsFollowUp,
    0,                                              -- SupervisionFollowUp,
    0,                                              -- OtherFollowUp,
    1,                                              -- CreatedBy,
    0,                                              -- Deleted,
    1,                                              -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),  -- LastModifiedDateTime
	53,												 -- CreatedByRoleId
	'all comments',
	'all comments',
	1,
	1,
	0,
	1
)

insert into LogDefinitionFunctionalLocation (LogDefinitionId, FunctionalLocationId)
values (7, @UnitLevelFloc2)

-- Log Definition with Recurring Daily Schedule
INSERT INTO [LogDefinition]
(
	Id,
    ScheduleId,
    CreatedDateTime,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    CreatedBy,
    Deleted,
    LastModifiedUserId,
    LastModifiedDateTime,
	CreatedByRoleId,
	RtfComments,
	PlainTextComments,
	LogType,
	CreateALogForEachFunctionalLocation,
	IsOperatingEngineerLog,
	Active
)
VALUES
(
	8,
    11,                                             -- ScheduleId,
    CONVERT(DATETIME, '2005-11-15 00:00:00', 102),  -- CreatedDateTime,
    0,                                              -- EHSFollowup,
    0,                                              -- ProcessControlFollowUp,
    0,                                              -- InspectionFollowUp,
    0,                                              -- OperationsFollowUp,
    0,                                              -- SupervisionFollowUp,
    0,                                              -- OtherFollowUp,
    1,                                              -- CreatedBy,
    0,                                              -- Deleted,
    1,                                              -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),  -- LastModifiedDateTime
	53,												 -- CreatedByRoleId
	'all comments',
	'all comments',
	1,
	1,
	0,
	1
)

insert into LogDefinitionFunctionalLocation (LogDefinitionId, FunctionalLocationId)
values (8, @UnitLevelFloc2)

SET IDENTITY_INSERT LogDefinition OFF
