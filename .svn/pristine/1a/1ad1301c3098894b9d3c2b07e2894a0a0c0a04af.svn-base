DECLARE @UnitLevelFloc1 AS BIGINT;
select @UnitLevelFloc1 = id from functionallocation where fullhierarchy = 'SR1-PLT3-BDP3';

DECLARE @UnitLevelFloc2 AS BIGINT;
select @UnitLevelFloc2 = id from functionallocation where fullhierarchy = 'SR1-OFFS';

DECLARE @UnitLevelFloc3 AS BIGINT;
select @UnitLevelFloc3 = id from functionallocation where fullhierarchy = 'SR1-OFFS-BDOF';

SET IDENTITY_INSERT TargetAlert ON

INSERT INTO [dbo].[TargetAlert]
(
    Id,
    TargetDefinitionId,
    TargetName,
    NeverToExceedMax,
    NeverToExceedMin,
    MaxValue,
    MinValue,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetAlertValue,
    GapUnitValue,
    TargetAlertStatusID,
    PriorityId,
    ExceedingBoundaries,
    TagID,
    FunctionalLocationID,
    LastModifiedUserId,
    LastModifiedDateTime,
    Description,
    CreatedDateTime,
    TargetCategoryID,
    CreatedByScheduleTypeId,
    ActualValue,
    OriginalExceedingValue,
	TypeOfViolationStatusId,
	LastViolatedDateTime,
	MaxAtEvaluation,
	MinAtEvaluation,
	NTEMaxAtEvaluation,
	NTEMinAtEvaluation,
	ActualValueAtEvaluation
	
)
VALUES
(
    1,                              -- Id
    1,                              -- TargetDefinitionId
    'Target Name',                  -- TargetName
    100,                            -- NeverToExceedMax
    20,                             -- NeverToExceedMin
    100,                            -- MaxValue
    20,                             -- MinValue
    1,                              -- NeverToExceedMaxFrequency
    1,                              -- NeverToExceedMinFrequency
    100,                            -- MaxValueFrequency
    1,                              -- MinValueFrequency
    0,                              -- TargetValueTypeId
    50,                             -- TargetAlertValue
    50,                             -- GapUnitValue
    0,                              -- TargetAlertStatusID
    1,                              -- Priority Normal
    1,								-- ExceedingBoundaries
    2,                              -- TagID
    @UnitLevelFloc2,                            -- FunctionalLocationID (SR1-OFFS)
    1,                              -- LastModifiedUserId
    '2005/10/10',                   -- LastModifiedDateTime
    'Test Target Alert Description',-- Description
    '2005/10/9',                    -- CreatedDateTime
    1,                              -- TargetCategoryID
    1,                              -- CreatedByScheduleTypeId
    150,                            -- ActualValue
    150,                            -- OriginalExceedingValue
	0,								-- TypeOfViolationStatusId,
	'2005/10/10',					-- LastViolatedDateTime,
	100, 							-- MaxAtEvaluation,
	20,								-- MinAtEvaluation,
	1,								-- NTEMaxAtEvaluation,
	1,								-- NTEMinAtEvaluation,
	1								-- ActualValueAtEvaluation
) 


--
-- Fort Murray TargetAlert
-- TargetAlertFixture.CreateFortMurrayTargetAlertFromDB() should returns this.
--
INSERT INTO [dbo].[TargetAlert]
(
    Id,
    TargetDefinitionId,
    TargetName,
    NeverToExceedMax,
    NeverToExceedMin,
    MaxValue,
    MinValue,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetAlertValue,
    GapUnitValue,
    TargetAlertStatusID,
    PriorityId,
    ExceedingBoundaries,
    TagID,
    FunctionalLocationID,
    LastModifiedUserId,
    LastModifiedDateTime,
    Description,
    CreatedDateTime,
    TargetCategoryID,
    CreatedByScheduleTypeId,
    ActualValue,
    OriginalExceedingValue,
	TypeOfViolationStatusId,
	LastViolatedDateTime,
	MaxAtEvaluation,
	MinAtEvaluation,
	NTEMaxAtEvaluation,
	NTEMinAtEvaluation,
	ActualValueAtEvaluation
)
VALUES
(
    2,                              -- Id
    1,                              -- TargetDefinitionId
    'Target Name Id = 2',           -- TargetName
    100,                            -- NeverToExceedMax
    20,                             -- NeverToExceedMin
    100,                            -- MaxValue
    20,                             -- MinValue
    1,                              -- NeverToExceedMaxFrequency
    1,                              -- NeverToExceedMinFrequency
    100,                            -- MaxValueFrequency
    1,                              -- MinValueFrequency
    0,                              -- TargetValueTypeId
    50,                             -- TargetAlertValue
    50,                             -- GapUnitValue
    0,                              -- TargetAlertStatusID
    1,                              -- Priority Normal
    1,								-- ExceedingBoundaries
    2,                              -- TagID
    @UnitLevelFloc3,                            -- FunctionalLocationID (SR1-OFFS-BDOF)
    1,                              -- LastModifiedUserId
    '2006-01-31',                   -- LastModifiedDateTime
    'From Sarnia FLOC, Id = 102',   -- Description
    '2005-01-19',                   -- CreatedDateTime
    1,                              -- TargetCategoryID
    1,                              -- CreatedByScheduleTypeId
    150,                            -- ActualValue
    150,                             -- OriginalExceedingValue
	0,								-- TypeOfViolationStatusId,
	'2005/10/10',					-- LastViolatedDateTime,
	100, 							-- MaxAtEvaluation,
	20,								-- MinAtEvaluation,
	1,								-- NTEMaxAtEvaluation,
	1,								-- NTEMinAtEvaluation,
	1								-- ActualValueAtEvaluation	
) 


--
-- Sarnia TargetAlert
-- TargetAlertFixture.CreateSarniaTargetAlertFromDB() should returns this.
--
INSERT INTO [dbo].[TargetAlert]
(
    Id,
    TargetDefinitionId,
    TargetName,
    NeverToExceedMax,
    NeverToExceedMin,
    MaxValue,
    MinValue,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetAlertValue,
    GapUnitValue,
    TargetAlertStatusID,
    PriorityId,
    ExceedingBoundaries,
    TagID,
    FunctionalLocationID,
    LastModifiedUserId,
    LastModifiedDateTime,
    Description,
    CreatedDateTime,
    TargetCategoryID,
    CreatedByScheduleTypeId,
    ActualValue,
    OriginalExceedingValue,
	TypeOfViolationStatusId,
	LastViolatedDateTime,
	MaxAtEvaluation,
	MinAtEvaluation,
	NTEMaxAtEvaluation,
	NTEMinAtEvaluation,
	ActualValueAtEvaluation	
)
VALUES
(
    3,                              -- Id
    1,                              -- TargetDefinitionId
    'Target Name Id = 3',           -- TargetName
    100,                            -- NeverToExceedMax
    20,                             -- NeverToExceedMin
    100,                            -- MaxValue
    20,                             -- MinValue
    1,                              -- NeverToExceedMaxFrequency
    1,                              -- NeverToExceedMinFrequency
    100,                            -- MaxValueFrequency
    1,                              -- MinValueFrequency
    0,                              -- TargetValueTypeId
    50,                             -- TargetAlertValue
    50,                             -- GapUnitValue
    1,                              -- TargetAlertStatusID
    1,                              -- Priority Normal
    1,                              -- ExceedingBoundaries
    2,                              -- TagID
    @UnitLevelFloc3,                              -- FunctionalLocationID (SR1-OFFS-BDOF)
    1,                              -- LastModifiedUserId
    '2005-01-31',                   -- LastModifiedDateTime
    'From Sarnia FLOC, Id = 3',     -- Description
    '2005-1-19',                    -- CreatedDateTime
    1,                              -- TargetCategoryID
    1,                              -- CreatedByScheduleTypeId
    150,                            -- ActualValue
    150,                            -- OriginalExceedingValue
	0,								-- TypeOfViolationStatusId,
	'2005/10/10',					-- LastViolatedDateTime,
	100, 							-- MaxAtEvaluation,
	20,								-- MinAtEvaluation,
	1,								-- NTEMaxAtEvaluation,
	1,								-- NTEMinAtEvaluation,
	1								-- ActualValueAtEvaluation	
) 

-- Setup a target alert with a response:
INSERT INTO [dbo].[TargetAlert]
(
    Id,
    TargetDefinitionId,
    RequiresResponse,
    TargetName,
    NeverToExceedMax,
    NeverToExceedMin,
    MaxValue,
    MinValue,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetAlertValue,
    GapUnitValue,
    TargetAlertStatusID,
    PriorityId,
    ExceedingBoundaries,
    TagID,
    FunctionalLocationID,
    LastModifiedUserId,
    LastModifiedDateTime,
    Description,
    CreatedDateTime,
    TargetCategoryID,
    CreatedByScheduleTypeId,
    ActualValue,
    OriginalExceedingValue,
	TypeOfViolationStatusId,
	LastViolatedDateTime,
	MaxAtEvaluation,
	MinAtEvaluation,
	NTEMaxAtEvaluation,
	NTEMinAtEvaluation,
	ActualValueAtEvaluation	
)
VALUES
(
    4,                              -- Id
    1,                              -- TargetDefinitionId
    1,                              -- RequiresResponse
    'Target Name Id = 4',           -- TargetName
    100,                            -- NeverToExceedMax
    20,                             -- NeverToExceedMin
    100,                            -- MaxValue
    20,                             -- MinValue
    1,                              -- NeverToExceedMaxFrequency
    1,                              -- NeverToExceedMinFrequency
    100,                            -- MaxValueFrequency
    1,                              -- MinValueFrequency
    0,                              -- TargetValueTypeId
    50,                             -- TargetAlertValue
    50,                             -- GapUnitValue
    1,                              -- TargetAlertStatusID
    1,                              -- Priority Normal
    1,                              -- ExceedingBoundaries
    2,                              -- TagID
    @UnitLevelFloc3,                              -- FunctionalLocationID (SR1-OFFS-BDOF)
    1,                              -- LastModifiedUserId
    '2005-02-01',                   -- LastModifiedDateTime
    'Id = 4, with response/comment',-- Description
    '2005-02-01',                    -- CreatedDateTime
    1,                              -- TargetCategoryID
    1,                              --CreatedByScheduleTypeId
    150,                            -- ActualValue
    150,                             -- OriginalExceedingValue
	0,								-- TypeOfViolationStatusId,
	'2005/10/10',					-- LastViolatedDateTime,
	100, 							-- MaxAtEvaluation,
	20,								-- MinAtEvaluation,
	1,								-- NTEMaxAtEvaluation,
	1,								-- NTEMinAtEvaluation,
	1								-- ActualValueAtEvaluation		
)

-- Setup a target alert for adding responses to:
INSERT INTO [dbo].[TargetAlert]
(
    Id,
    TargetDefinitionId,
    RequiresResponse,
    TargetName,
    NeverToExceedMax,
    NeverToExceedMin,
    MaxValue,
    MinValue,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetAlertValue,
    GapUnitValue,
    TargetAlertStatusID,
    PriorityId,
    ExceedingBoundaries,
    TagID,
    FunctionalLocationID,
    LastModifiedUserId,
    LastModifiedDateTime,
    Description,
    CreatedDateTime,
    TargetCategoryID,
    CreatedByScheduleTypeId,
    ActualValue,
    OriginalExceedingValue,
	TypeOfViolationStatusId,
	LastViolatedDateTime,
	MaxAtEvaluation,
	MinAtEvaluation,
	NTEMaxAtEvaluation,
	NTEMinAtEvaluation,
	ActualValueAtEvaluation	
)
VALUES
(
    5,                              -- Id
    1,                              -- TargetDefinitionId
    1,                              -- RequiresResponse
    'Target Name Id = 5',           -- TargetName
    100,                            -- NeverToExceedMax
    20,                             -- NeverToExceedMin
    100,                            -- MaxValue
    20,                             -- MinValue
    1,                              -- NeverToExceedMaxFrequency
    1,                              -- NeverToExceedMinFrequency
    100,                            -- MaxValueFrequency
    1,                              -- MinValueFrequency
    0,                              -- TargetValueTypeId
    50,                             -- TargetAlertValue
    50,                             -- GapUnitValue
    1,                              -- TargetAlertStatusID
    1,                              -- Priority Normal
    1,                              -- ExceedingBoundaries
    2,                              -- TagID
    @UnitLevelFloc3,                            -- FunctionalLocationID (SR1-OFFS-BDOF)
    1,                              -- LastModifiedUserId
    '2005-02-02',                   -- LastModifiedDateTime
    'Id = 5, with response/comment',-- Description
    '2005-02-02',                    -- CreatedDateTime
    1,                              -- TargetCategoryID
    1,                              --CreatedByScheduleTypeId
    150,                            -- ActualValue
    150,                             -- OriginalExceedingValue
	0,								-- TypeOfViolationStatusId,
	'2005/10/10',					-- LastViolatedDateTime,
	100, 							-- MaxAtEvaluation,
	20,								-- MinAtEvaluation,
	1,								-- NTEMaxAtEvaluation,
	1,								-- NTEMinAtEvaluation,
	1								-- ActualValueAtEvaluation		
)

--
-- Target Alerts with different scenarios of Actual Value
--

INSERT INTO [dbo].[TargetAlert]
(
    Id,
    TargetDefinitionId,
    TargetName,
    NeverToExceedMax,
    NeverToExceedMin,
    MaxValue,
    MinValue,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetAlertValue,
    GapUnitValue,
    TargetAlertStatusID,
    PriorityId,
    ExceedingBoundaries,
    TagID,
    FunctionalLocationID,
    LastModifiedUserId,
    LastModifiedDateTime,
    Description,
    CreatedDateTime,
    TargetCategoryID,
    CreatedByScheduleTypeId,
    ActualValue,
    OriginalExceedingValue,
	TypeOfViolationStatusId,
	LastViolatedDateTime,
	MaxAtEvaluation,
	MinAtEvaluation,
	NTEMaxAtEvaluation,
	NTEMinAtEvaluation,
	ActualValueAtEvaluation	
)
VALUES
(
    6,                              -- Id
    1,                              -- TargetDefinitionId
    'Target Alert Id = 6',               -- TargetName
    150,                            -- NeverToExceedMax
    0,                              -- NeverToExceedMin
    100,                            -- MaxValue
    50,                             -- MinValue
    1,                              -- NeverToExceedMaxFrequency
    1,                              -- NeverToExceedMinFrequency
    100,                            -- MaxValueFrequency
    1,                              -- MinValueFrequency
    0,                              -- TargetValueTypeId
    50,                             -- TargetAlertValue
    50,                             -- GapUnitValue
    0,                              -- TargetAlertStatusID
    1,                              -- Priority Normal
    1,                              -- ExceedingBoundaries
    2,                              -- TagID
    @UnitLevelFloc3,                            -- FunctionalLocationID
    1,                              -- LastModifiedUserId
    GETDATE(),                      -- LastModifiedDateTime
    'Alert that goes outside the range, with subsequent reading of a different value but still out of range.',-- Description
    GETDATE(),                      -- CreatedDateTime
    1,                              -- TargetCategoryID
    1,                              -- CreatedByScheduleTypeId
    110,                            -- ActualValue
    120,                            -- OriginalExceedingValue
	0,								-- TypeOfViolationStatusId,
	'2005/10/10',					-- LastViolatedDateTime,
	100, 							-- MaxAtEvaluation,
	20,								-- MinAtEvaluation,
	1,								-- NTEMaxAtEvaluation,
	1,								-- NTEMinAtEvaluation,
	1								-- ActualValueAtEvaluation		
)

INSERT INTO [dbo].[TargetAlert]
(
    Id,
    TargetDefinitionId,
    TargetName,
    NeverToExceedMax,
    NeverToExceedMin,
    MaxValue,
    MinValue,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetAlertValue,
    GapUnitValue,
    TargetAlertStatusID,
    PriorityId,
    ExceedingBoundaries,
    TagID,
    FunctionalLocationID,
    LastModifiedUserId,
    LastModifiedDateTime,
    Description,
    CreatedDateTime,
    TargetCategoryID,
    CreatedByScheduleTypeId,
    ActualValue,
    OriginalExceedingValue,
	TypeOfViolationStatusId,
	LastViolatedDateTime,
	MaxAtEvaluation,
	MinAtEvaluation,
	NTEMaxAtEvaluation,
	NTEMinAtEvaluation,
	ActualValueAtEvaluation	
)
VALUES
(
    7,                              -- Id
    1,                              -- TargetDefinitionId
    'Target Alert Id = 7',               -- TargetName
    150,                            -- NeverToExceedMax
    0,                              -- NeverToExceedMin
    100,                            -- MaxValue
    50,                             -- MinValue
    1,                              -- NeverToExceedMaxFrequency
    1,                              -- NeverToExceedMinFrequency
    100,                            -- MaxValueFrequency
    1,                              -- MinValueFrequency
    0,                              -- TargetValueTypeId
    50,                             -- TargetAlertValue
    50,                             -- GapUnitValue
    0,                              -- TargetAlertStatusID
    1,                              -- Priority Normal
    0,                              -- ExceedingBoundaries
    2,                              -- TagID
    @UnitLevelFloc3,                            -- FunctionalLocationID
    1,                              -- LastModifiedUserId
    GETDATE(),                      -- LastModifiedDateTime
    'Alert that goes outside the range, with subsequent reading in range.',-- Description
    GETDATE(),                      -- CreatedDateTime
    1,                              -- TargetCategoryID
    1,                              -- CreatedByScheduleTypeId
    75,                             -- ActualValue
    110,                            -- OriginalExceedingValue
	0,								-- TypeOfViolationStatusId,
	'2005/10/10',					-- LastViolatedDateTime,
	100, 							-- MaxAtEvaluation,
	20,								-- MinAtEvaluation,
	1,								-- NTEMaxAtEvaluation,
	1,								-- NTEMinAtEvaluation,
	1								-- ActualValueAtEvaluation		
) 


INSERT INTO [dbo].[TargetAlert]
(
    Id,
    TargetDefinitionId,
    TargetName,
    NeverToExceedMax,
    NeverToExceedMin,
    MaxValue,
    MinValue,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetAlertValue,
    GapUnitValue,
    TargetAlertStatusID,
    PriorityId,
    ExceedingBoundaries,
    TagID,
    FunctionalLocationID,
    LastModifiedUserId,
    LastModifiedDateTime,
    Description,
    CreatedDateTime,
    TargetCategoryID,
    CreatedByScheduleTypeId,
    ActualValue,
    OriginalExceedingValue,
	TypeOfViolationStatusId,
	LastViolatedDateTime,
	MaxAtEvaluation,
	MinAtEvaluation,
	NTEMaxAtEvaluation,
	NTEMinAtEvaluation,
	ActualValueAtEvaluation	
)
VALUES
(
    8,                              -- Id
    1,                              -- TargetDefinitionId
    'Target Alert Id = 8',               -- TargetName
    150,                            -- NeverToExceedMax
    0,                              -- NeverToExceedMin
    100,                            -- MaxValue
    50,                             -- MinValue
    1,                              -- NeverToExceedMaxFrequency
    1,                              -- NeverToExceedMinFrequency
    100,                            -- MaxValueFrequency
    1,                              -- MinValueFrequency
    0,                              -- TargetValueTypeId
    50,                             -- TargetAlertValue
    50,                             -- GapUnitValue
    0,                              -- TargetAlertStatusID
    1,                              -- Priority Normal
    0,                              -- ExceedingBoundaries
    2,                              -- TagID
    @UnitLevelFloc3,                            -- FunctionalLocationID
    1,                              -- LastModifiedUserId
    GETDATE(),                      -- LastModifiedDateTime
    'Legacy target alert that has no value for original exceeding value, and actual value is in range.',-- Description
    GETDATE(),                      -- CreatedDateTime
    1,                              -- TargetCategoryID
    1,                              -- CreatedByScheduleTypeId
    75,                             -- ActualValue
    null,                             -- OriginalExceedingValue
	0,								-- TypeOfViolationStatusId,
	'2005/10/10',					-- LastViolatedDateTime,
	100, 							-- MaxAtEvaluation,
	20,								-- MinAtEvaluation,
	1,								-- NTEMaxAtEvaluation,
	1,								-- NTEMinAtEvaluation,
	1								-- ActualValueAtEvaluation		
) 

INSERT INTO [dbo].[TargetAlert]
(
    Id,
    TargetDefinitionId,
    TargetName,
    NeverToExceedMax,
    NeverToExceedMin,
    MaxValue,
    MinValue,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetAlertValue,
    GapUnitValue,
    TargetAlertStatusID,
    PriorityId,
    ExceedingBoundaries,
    TagID,
    FunctionalLocationID,
    LastModifiedUserId,
    LastModifiedDateTime,
    Description,
    CreatedDateTime,
    TargetCategoryID,
    CreatedByScheduleTypeId,
    ActualValue,
    OriginalExceedingValue,
	TypeOfViolationStatusId,
	LastViolatedDateTime,
	MaxAtEvaluation,
	MinAtEvaluation,
	NTEMaxAtEvaluation,
	NTEMinAtEvaluation,
	ActualValueAtEvaluation	
)
VALUES
(
    9,                              -- Id
    1,                              -- TargetDefinitionId
    'Target Alert Id = 9',               -- TargetName
    150,                            -- NeverToExceedMax
    0,                              -- NeverToExceedMin
    100,                            -- MaxValue
    50,                             -- MinValue
    1,                              -- NeverToExceedMaxFrequency
    1,                              -- NeverToExceedMinFrequency
    100,                            -- MaxValueFrequency
    1,                              -- MinValueFrequency
    0,                              -- TargetValueTypeId
    50,                             -- TargetAlertValue
    50,                             -- GapUnitValue
    0,                              -- TargetAlertStatusID
    1,                              -- Priority Normal
    0,                              -- ExceedingBoundaries
    2,                              -- TagID
    @UnitLevelFloc1,                          -- FunctionalLocationID (SR1-PLT3-BDP3)
    1,                              -- LastModifiedUserId
    GETDATE(),                      -- LastModifiedDateTime
    'Legacy target alert that has no value for original exceeding value, and actual value is in range.',-- Description
    GETDATE(),                      -- CreatedDateTime
    1,                              -- TargetCategoryID
    1,                              -- CreatedByScheduleTypeId
    75,                             -- ActualValue
    null,                            -- OriginalExceedingValue
	0,								-- TypeOfViolationStatusId,
	'2005/10/10',					-- LastViolatedDateTime,
	100, 							-- MaxAtEvaluation,
	20,								-- MinAtEvaluation,
	1,								-- NTEMaxAtEvaluation,
	1,								-- NTEMinAtEvaluation,
	1								-- ActualValueAtEvaluation		
) 

SET IDENTITY_INSERT TargetAlert OFF
