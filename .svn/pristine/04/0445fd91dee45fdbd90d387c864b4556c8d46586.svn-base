DECLARE @UnitLevelFloc1 AS BIGINT;
select @UnitLevelFloc1 = id from functionallocation where fullhierarchy = 'SR1-PLT1';
DECLARE @UnitLevelFloc2 AS BIGINT;
select @UnitLevelFloc2 = id from functionallocation where fullhierarchy = 'SR1-OFFS';
DECLARE @UnitLevelFloc3 AS BIGINT;
select @UnitLevelFloc3 = id from functionallocation where fullhierarchy = 'SR1-OFFS-BDOF';
DECLARE @UnitLevelFloc4 AS BIGINT;
select @UnitLevelFloc4 = id from functionallocation where fullhierarchy = 'SR1';

-- Test Data for testing delete of a Child Target definition that has a parent target definition
SET IDENTITY_INSERT TargetDefinition ON
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],

    [AlertRequired],
    [RequiresResponseWhenAlerted]
)	
VALUES
(
    6,
    'TestData Target 5',
    104,
    null,
    null,
    null,
    1,
    null,
    null,
    null,
    50,         -- Target
    0,          -- Target value type
    50,
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc1,
    1,
    '2005/1/4',
    0,
    4,
    'Recurring Daily',
    1,

    0,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinitionState] VALUES(6, 1, null)

INSERT INTO [dbo].[TargetDefinition]
(
    [Id],

    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],

    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],

    [GapUnitValue],
    [TargetDefinitionStatusID],
    [TagID],
    [FunctionalLocationID],

    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],

    [TargetCategoryID],

    [AlertRequired],
    [RequiresResponseWhenAlerted],
    [OperationalModeId])
VALUES
(
    1,

    'Parent with association',
    50,
    10,
    100,
    0,

    1,
    1,
    100,
    1,
    50,         -- Target
    0,          -- Target value type

    50,
    2,      -- Status (Approved)
    2,
    @UnitLevelFloc2,

    1,
    '2005/1/1',
    0,
    18,
    'This is the parent target for testing delete of child target',

    1,

    0,         -- AlertRequired
    0,         -- RequiresResponseWhenAlerted
    2)

INSERT INTO [dbo].[TargetDefinition]
(
[Id],

    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],

    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],

    [GapUnitValue],
    [TargetDefinitionStatusID],
    [TagID],
    [FunctionalLocationID],

    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],

    [TargetCategoryID],

    [AlertRequired],
    [RequiresResponseWhenAlerted])
VALUES
(
    2,

    'Child with association',
    50,
    10,
    100,
    0,

    1,
    1,
    100,
    1,
    50,         -- Target
    0,          -- Target value type

    50,
    2,      -- Status (Approved)
    2,
    @UnitLevelFloc2,

    1,
    '2005/1/1',
    0,
    19,
    'This is the child target for testing delete of child target',

    1,

    0,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
)

INSERT INTO [dbo].[TargetDefinitionAssociation]
    ([ParentTargetDefinitionId], [ChildTargetDefinitionId])
VALUES
    (1, 2);



-- Target Definition with no comments
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],

    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    5,                          -- [Id]
    'TestData Target Id = 5',   -- [Name]
    50,                         -- [NeverToExceedMax]
    10,                         -- [NeverToExceedMin]
    100,                        -- [MaxValue]
    0,                          -- [MinValue]
    1,                          -- [NeverToExceedMaxFrequency],
    1,                          -- [NeverToExceedMinFrequency],
    100,                        -- [MaxValueFrequency],
    1,                          -- [MinValueFrequency],
    50,                         -- [TargetDefinitionValue],
    0,                          -- [TargetValueTypeId],
    50,                         -- [GapUnitValue],
    2,                          -- [TargetDefinitionStatusID],
    0,                          -- [RequiresApproval]
    1,                          -- [IsActive]
    2,                          -- [TagID],
    @UnitLevelFloc2,                        -- [FunctionalLocationID],
    1,                          -- [LastModifiedUserId],
    '2005/1/1',                 -- [LastModifiedDateTime],
    0,                          -- [Deleted],
    22,                         -- [ScheduleID],
    'Waiting for comments to be added',   -- [Description],
    1,                              -- [TargetCategoryID],

    0,                              -- [AlertRequired]
    0                              -- [RequiresResponseWhenAlerted]
)
	
--
-- Target Definition with 2 comments and has record in Audit Trail
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],

    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    7,                          -- [Id]
    'TestData Target Id = 7',   -- [Name]
    50,                         -- [NeverToExceedMax]
    10,                         -- [NeverToExceedMin]
    100,                        -- [MaxValue]
    0,                          -- [MinValue]
    1,                          -- [NeverToExceedMaxFrequency],
    1,                          -- [NeverToExceedMinFrequency],
    100,                        -- [MaxValueFrequency],
    1,                          -- [MinValueFrequency],
    50,                         -- [TargetDefinitionValue],
    0,                          -- [TargetValueTypeId],
    50,                         -- [GapUnitValue],
    2,                          -- [TargetDefinitionStatusID],
    0,                          -- [RequiresApproval]
    1,                          -- [IsActive]
    2,                          -- [TagID],
    @UnitLevelFloc3,                        -- [FunctionalLocationID],
    1,                          -- [LastModifiedUserId],
    '2005/1/1',                 -- [LastModifiedDateTime],
    0,                          -- [Deleted],
    23,                         -- [ScheduleID],
    'Has 2 comments and has audit trail record', -- [Description],
    1,                              -- [TargetCategoryID],

    0,                              -- [AlertRequired]
    0                              -- [RequiresResponseWhenAlerted]
);

INSERT INTO [TargetDefinitionComment] ([TargetDefinitionId], [CommentId]) VALUES (7, 1);
INSERT INTO [TargetDefinitionComment] ([TargetDefinitionId], [CommentId]) VALUES (7, 2);

--
-- Target Definition with 2 Associated Target Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    8,                          -- [Id]
    'TestData Target Id = 8',   -- [Name]
    50,                         -- [NeverToExceedMax]
    10,                         -- [NeverToExceedMin]
    100,                        -- [MaxValue]
    0,                          -- [MinValue]
    1,                          -- [NeverToExceedMaxFrequency],
    1,                          -- [NeverToExceedMinFrequency],
    100,                        -- [MaxValueFrequency],
    1,                          -- [MinValueFrequency],
    50,                         -- [TargetDefinitionValue],
    0,                          -- [TargetValueTypeId],
    50,                         -- [GapUnitValue],
    2,                          -- [TargetDefinitionStatusID],
    0,                          -- [RequiresApproval]
    1,                          -- [IsActive]
    2,                          -- [TagID],
    @UnitLevelFloc3,                        -- [FunctionalLocationID],
    1,                          -- [LastModifiedUserId],
    '2005/1/1',                 -- [LastModifiedDateTime],
    0,                          -- [Deleted],
    24,                         -- [ScheduleID],
    'Has 2 Associated Targets - Id 9, 10', -- [Description],
    1,                          -- [TargetCategoryID],

    0,                          -- [AlertRequired]
    0                          -- [RequiresResponseWhenAlerted]
);


--
-- Target Definition that has a parent
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    9,                          -- [Id]
    'TestData Target Id = 9',   -- [Name]
    50,                         -- [NeverToExceedMax]
    10,                         -- [NeverToExceedMin]
    100,                        -- [MaxValue]
    0,                          -- [MinValue]
    1,                          -- [NeverToExceedMaxFrequency],
    1,                          -- [NeverToExceedMinFrequency],
    100,                        -- [MaxValueFrequency],
    1,                          -- [MinValueFrequency],
    50,                         -- [TargetDefinitionValue],
    0,                          -- [TargetValueTypeId],
    50,                         -- [GapUnitValue],
    2,                          -- [TargetDefinitionStatusID],
    0,                          -- [RequiresApproval]
    1,                          -- [IsActive]
    2,                          -- [TagID],
    @UnitLevelFloc3,                        -- [FunctionalLocationID],
    1,                          -- [LastModifiedUserId],
    '2005/1/1',                 -- [LastModifiedDateTime],
    0,                          -- [Deleted],
    25,                         -- [ScheduleID],
    'Its Parent Id = 8',        -- [Description],
    1,                          -- [TargetCategoryID],

    0,                          -- [AlertRequired]
    0                          -- [RequiresResponseWhenAlerted]
);
INSERT INTO [dbo].[TargetDefinitionAssociation]
    ([ParentTargetDefinitionId], [ChildTargetDefinitionId])
VALUES
    (8, 9);

--
-- Target Definition that has a parent
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    10,                         -- [Id]
    'TestData Target Id = 10',  -- [Name]
    50,                         -- [NeverToExceedMax]
    10,                         -- [NeverToExceedMin]
    100,                        -- [MaxValue]
    0,                          -- [MinValue]
    1,                          -- [NeverToExceedMaxFrequency],
    1,                          -- [NeverToExceedMinFrequency],
    100,                        -- [MaxValueFrequency],
    1,                          -- [MinValueFrequency],
    50,                         -- [TargetDefinitionValue],
    0,                          -- [TargetValueTypeId],
    50,                         -- [GapUnitValue],
    2,                          -- [TargetDefinitionStatusID],
    0,                          -- [RequiresApproval]
    1,                          -- [IsActive]
    2,                          -- [TagID],
    @UnitLevelFloc3,                        -- [FunctionalLocationID],
    1,                          -- [LastModifiedUserId],
    '2005/1/1',                 -- [LastModifiedDateTime],
    0,                          -- [Deleted],
    26,                         -- [ScheduleID],
    'Its Parent Id = 8',        -- [Description],
    1,                          -- [TargetCategoryID],

    0,                          -- [AlertRequired]
    0                          -- [RequiresResponseWhenAlerted]
);
INSERT INTO [dbo].[TargetDefinitionAssociation]
    ([ParentTargetDefinitionId], [ChildTargetDefinitionId])
VALUES
    (8, 10);

--
-- Unit Guideline/Process Target Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    11,                                         -- [Id]
    'Id = 11 Unit Guideline/Process',           -- [Name]
    1,                                          -- [NeverToExceedMax]
    1,                                          -- [NeverToExceedMin]
    1,                                          -- [MaxValue]
    1,                                          -- [MinValue]
    1,                                          -- [NeverToExceedMaxFrequency],
    1,                                          -- [NeverToExceedMinFrequency],
    100,                                        -- [MaxValueFrequency],
    1,                                          -- [MinValueFrequency],
    1,                                          -- [TargetDefinitionValue],
    0,                                          -- [TargetValueTypeId],
    1,                                          -- [GapUnitValue],
    1,                                          -- [TargetDefinitionStatusID],
    1,                                          -- [RequiresApproval]
    0,                                          -- [IsActive]
    2,                                          -- [TagID],
    @UnitLevelFloc3,                                        -- [FunctionalLocationID],
    1,                                          -- [LastModifiedUserId],
    '2005/1/1',                                 -- [LastModifiedDateTime],
    0,                                          -- [Deleted],
    27,                                         -- [ScheduleID],
    'Id = 11 Unit Guideline/Process Target',    -- [Description],
    1,                                          -- [TargetCategoryID],

    0,                                          -- [AlertRequired]
    0                                          -- [RequiresResponseWhenAlerted]
);


--
-- Production Target Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    12,                                         -- [Id]
    'Id = 12 Production Target',                -- [Name]
    1,                                          -- [NeverToExceedMax]
    1,                                          -- [NeverToExceedMin]
    1,                                          -- [MaxValue]
    1,                                          -- [MinValue]
    1,                                          -- [NeverToExceedMaxFrequency],
    1,                                          -- [NeverToExceedMinFrequency],
    100,                                        -- [MaxValueFrequency],
    1,                                          -- [MinValueFrequency],
    1,                                          -- [TargetDefinitionValue],
    0,                                          -- [TargetValueTypeId],
    1,                                          -- [GapUnitValue],
    1,                                          -- [TargetDefinitionStatusID],
    1,                                          -- [RequiresApproval]
    0,                                          -- [IsActive]
    2,                                          -- [TagID],
    @UnitLevelFloc3,                                        -- [FunctionalLocationID],
    1,                                          -- [LastModifiedUserId],
    '2005/1/1',                                 -- [LastModifiedDateTime],
    0,                                          -- [Deleted],
    28,                                         -- [ScheduleID],
    'Id = 12 Production Target',                -- [Description],
    2,                                          -- [TargetCategoryID],

    0,                                          -- [AlertRequired]
    0                                          -- [RequiresResponseWhenAlerted]
);

--
-- Environmental/SafetyTarget Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    13,                                         -- [Id]
    'Id = 13 Environmental/Safety',             -- [Name]
    1,                                          -- [NeverToExceedMax]
    1,                                          -- [NeverToExceedMin]
    1,                                          -- [MaxValue]
    1,                                          -- [MinValue]
    1,                                          -- [NeverToExceedMaxFrequency]
    1,                                          -- [NeverToExceedMinFrequency]
    100,                                        -- [MaxValueFrequency]
    1,                                          -- [MinValueFrequency]
    1,                                          -- [TargetDefinitionValue]
    0,                                          -- [TargetValueTypeId],
    1,                                          -- [GapUnitValue]
    1,                                          -- [TargetDefinitionStatusID]
    1,                                          -- [RequiresApproval]
    0,                                          -- [IsActive]
    2,                                          -- [TagID]
    @UnitLevelFloc3,                                        -- [FunctionalLocationID]
    1,                                          -- [LastModifiedUserId]
    '2005/1/1',                                 -- [LastModifiedDateTime]
    0,                                          -- [Deleted]
    29,                                         -- [ScheduleID]
    'Id = 13 Environmental/Safety Target',      -- [Description]
    3,                                          -- [TargetCategoryID]

    0,                                          -- [AlertRequired]
    0                                          -- [RequiresResponseWhenAlerted]
);

--
-- Product Specification Target Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    14,                                         -- [Id]
    'Id = 14 Product Specification',            -- [Name]
    1,                                          -- [NeverToExceedMax]
    1,                                          -- [NeverToExceedMin]
    1,                                          -- [MaxValue]
    1,                                          -- [MinValue]
    1,                                          -- [NeverToExceedMaxFrequency],
    1,                                          -- [NeverToExceedMinFrequency],
    100,                                        -- [MaxValueFrequency],
    1,                                          -- [MinValueFrequency],
    1,                                          -- [TargetDefinitionValue],
    0,                                          -- [TargetValueTypeId],
    1,                                          -- [GapUnitValue],
    1,                                          -- [TargetDefinitionStatusID],
    1,                                          -- [RequiresApproval]
    0,                                          -- [IsActive]
    2,                                          -- [TagID],
    @UnitLevelFloc3,                                        -- [FunctionalLocationID],
    1,                                          -- [LastModifiedUserId],
    '2005/1/1',                                 -- [LastModifiedDateTime],
    0,                                          -- [Deleted],
    30,                                         -- [ScheduleID],
    'Id = 14 Product Specification Target',     -- [Description],
    4,                                          -- [TargetCategoryID],

    0,                                          -- [AlertRequired]
    0                                          -- [RequiresResponseWhenAlerted]
);

--
-- Energy Management Target Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    15,                                         -- [Id]
    'Id = 15 Energy Management',                -- [Name]
    1,                                          -- [NeverToExceedMax]
    1,                                          -- [NeverToExceedMin]
    1,                                          -- [MaxValue]
    1,                                          -- [MinValue]
    1,                                          -- [NeverToExceedMaxFrequency],
    1,                                          -- [NeverToExceedMinFrequency],
    100,                                        -- [MaxValueFrequency],
    1,                                          -- [MinValueFrequency],
    1,                                          -- [TargetDefinitionValue],
    0,                                          -- [TargetValueTypeId],
    1,                                          -- [GapUnitValue],
    1,                                          -- [TargetDefinitionStatusID],
    1,                                          -- [RequiresApproval]
    0,                                          -- [IsActive]
    2,                                          -- [TagID],
    @UnitLevelFloc3,                                        -- [FunctionalLocationID],
    1,                                          -- [LastModifiedUserId],
    '2005/1/1',                                 -- [LastModifiedDateTime],
    0,                                          -- [Deleted],
    31,                                         -- [ScheduleID],
    'Id = 15 Energy Management Target',        -- [Description],
    5,                                          -- [TargetCategoryID],

    0,                                          -- [AlertRequired]
    0                                           -- [RequiresResponseWhenAlerted]
);


--
-- Pending Target Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    16,                                         -- [Id]
    'Id = 16 Pending Target Def',               -- [Name]
    1,                                          -- [NeverToExceedMax]
    1,                                          -- [NeverToExceedMin]
    1,                                          -- [MaxValue]
    1,                                          -- [MinValue]
    1,                                          -- [NeverToExceedMaxFrequency],
    1,                                          -- [NeverToExceedMinFrequency],
    100,                                        -- [MaxValueFrequency],
    1,                                          -- [MinValueFrequency],
    1,                                          -- [TargetDefinitionValue],
    0,                                          -- [TargetValueTypeId],
    1,                                          -- [GapUnitValue],
    1,                                          -- [TargetDefinitionStatusID],
    1,                                          -- [RequiresApproval]
    0,                                          -- [IsActive]
    2,                                          -- [TagID],
    @UnitLevelFloc3,                                        -- [FunctionalLocationID],
    1,                                          -- [LastModifiedUserId],
    '2005/1/1',                                 -- [LastModifiedDateTime],
    0,                                          -- [Deleted],
    32,                                         -- [ScheduleID],
    'Id = 16 Pending Target Definition',        -- [Description],
    5,                                          -- [TargetCategoryID],

    0,                                          -- [AlertRequired]
    0                                          -- [RequiresResponseWhenAlerted]
);

--
-- Approved Target Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    17,                                         -- [Id]
    'Id = 17 Approved Target Def',              -- [Name]
    1,                                          -- [NeverToExceedMax]
    1,                                          -- [NeverToExceedMin]
    1,                                          -- [MaxValue]
    1,                                          -- [MinValue]
    1,                                          -- [NeverToExceedMaxFrequency],
    1,                                          -- [NeverToExceedMinFrequency],
    100,                                        -- [MaxValueFrequency],
    1,                                          -- [MinValueFrequency],
    1,                                          -- [TargetDefinitionValue],
    0,                                          -- [TargetValueTypeId],
    1,                                          -- [GapUnitValue],
    2,                                          -- [TargetDefinitionStatusID],
    0,                                          -- [RequiresApproval]
    0,                                          -- [IsActive]
    2,                                          -- [TagID],
    @UnitLevelFloc3,                                        -- [FunctionalLocationID],
    1,                                          -- [LastModifiedUserId],
    '2005/1/1',                                 -- [LastModifiedDateTime],
    0,                                          -- [Deleted],
    33,                                         -- [ScheduleID],
    'Id = 17 Approved Target Definition',       -- [Description],
    5,                                          -- [TargetCategoryID],

    0,                                          -- [AlertRequired]
    0                                           -- [RequiresResponseWhenAlerted]
);

--
-- InActive Target Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    18,                                         -- [Id]
    'Id = 18 InActive Target Def',              -- [Name]
    1,                                          -- [NeverToExceedMax]
    1,                                          -- [NeverToExceedMin]
    1,                                          -- [MaxValue]
    1,                                          -- [MinValue]
    1,                                          -- [NeverToExceedMaxFrequency],
    1,                                          -- [NeverToExceedMinFrequency],
    100,                                        -- [MaxValueFrequency],
    1,                                          -- [MinValueFrequency],
    1,                                          -- [TargetDefinitionValue],
    0,                                          -- [TargetValueTypeId],
    1,                                          -- [GapUnitValue],
    1,                                          -- [TargetDefinitionStatusID],
    1,                                          -- [RequiresApproval]
    1,                                          -- [IsActive]
    2,                                          -- [TagID],
    @UnitLevelFloc3,                                        -- [FunctionalLocationID],
    1,                                          -- [LastModifiedUserId],
    '2005/1/1',                                 -- [LastModifiedDateTime],
    0,                                          -- [Deleted],
    34,                                         -- [ScheduleID],
    'Id = 18 (Obsolete Status but it is for testing purpose only)',  -- [Description],
    5,                                          -- [TargetCategoryID],

    0,                                          -- [AlertRequired]
    0                                          -- [RequiresResponseWhenAlerted]
);

--
-- Rejected Target Definition
--
INSERT INTO [dbo].[TargetDefinition]
(
    [Id],
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue], 
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    19,                                         -- [Id]
    'Id = 19 Rejected Target Def',                -- [Name]
    1,                                          -- [NeverToExceedMax]
    1,                                          -- [NeverToExceedMin]
    1,                                          -- [MaxValue]
    1,                                          -- [MinValue]
    1,                                          -- [NeverToExceedMaxFrequency],
    1,                                          -- [NeverToExceedMinFrequency],
    100,                                        -- [MaxValueFrequency],
    1,                                          -- [MinValueFrequency],
    1,                                          -- [TargetDefinitionValue],
    0,                                          -- [TargetValueTypeId],
    1,                                          -- [GapUnitValue],
    4,                                          -- [TargetDefinitionStatusID],
    1,                                          -- [RequiresApproval]
    0,                                          -- [IsActive]
    2,                                          -- [TagID],
    @UnitLevelFloc3,                                        -- [FunctionalLocationID],
    1,                                          -- [LastModifiedUserId],
    '2005/1/1',                                 -- [LastModifiedDateTime],
    0,                                          -- [Deleted],
    35,                                         -- [ScheduleID],
    'Id = 19 Rejected Target Def',              -- [Description],
    5,                                          -- [TargetCategoryID],

    0,                                          -- [AlertRequired]
    0                                           -- [RequiresResponseWhenAlerted]
);

INSERT INTO TargetDefinition
                      (Id,
                       Name, TargetDefinitionStatusID, TargetCategoryID, TagID,
                       FunctionalLocationID, LastModifiedUserId, LastModifiedDateTime, Deleted, 
                      GenerateActionItem, ScheduleId, AlertRequired, RequiresApproval, RequiresResponseWhenAlerted,
                       IsActive, OperationalModeId, TargetValueTypeId, Description)
					   
VALUES     (-1, 
			'Test Target',2,1,11,
			100,1,CONVERT(DATETIME, '2005-11-01 00:00:00', 102),0,
			1,36,0,1,
			0,0,1,1, 'Test Target Id = -1 Description')

INSERT INTO TargetDefinition
                      (Id, Name, TargetDefinitionStatusID, TargetCategoryID, TagID,
                       FunctionalLocationID, LastModifiedUserId, LastModifiedDateTime, Deleted, 
                      GenerateActionItem, ScheduleId, AlertRequired, RequiresApproval, RequiresResponseWhenAlerted,
                       IsActive, OperationalModeId, TargetValueTypeId, Description)
VALUES     (-2, 
			'Test Target 2',2,1,11,
			100,1,CONVERT(DATETIME, '2005-11-01 00:00:00', 102),0,
			1,37,0,1,0,0,1,1, 'Test Target Id = -2 Description')

INSERT INTO TargetDefinition
                      (Id, Name, TargetDefinitionStatusID, TargetCategoryID, TagID,
                       FunctionalLocationID, LastModifiedUserId, LastModifiedDateTime, Deleted, 
                      GenerateActionItem, ScheduleId, AlertRequired, RequiresApproval, RequiresResponseWhenAlerted,
                       IsActive, OperationalModeId, TargetValueTypeId, Description)
VALUES     (-3, 'Test Target 3',2,1,11,
			100,1,CONVERT(DATETIME, '2005-11-01 00:00:00', 102),0,
			1,38,0,1,0,1,1,1, 'Test Target Id = -3 Description')


SET IDENTITY_INSERT TargetDefinition OFF


 SET IDENTITY_INSERT TargetDefinitionReadWriteTagConfiguration ON

INSERT INTO TargetDefinitionReadWriteTagConfiguration
                      (Id, MaxDirectionId, MaxTagId, MinDirectionId, MinTagId, TargetDirectionId, TargetTagId, GapUnitValueDirectionId, GapUnitValueTagId, TargetDefinitionId)
VALUES     (-2, 2, 5, 0, 6, 0, 7, 0, 8, -1)

INSERT INTO TargetDefinitionReadWriteTagConfiguration
                      (Id, MaxDirectionId, MaxTagId, MinDirectionId, MinTagId, TargetDirectionId, TargetTagId, GapUnitValueDirectionId, GapUnitValueTagId, TargetDefinitionId)
VALUES     (-3, 2, 9, 2, 6, 0, 7, 2, 14, -2)

INSERT INTO TargetDefinitionReadWriteTagConfiguration
                      (Id, MaxDirectionId, MaxTagId, MinDirectionId, MinTagId, TargetDirectionId, TargetTagId, GapUnitValueDirectionId, GapUnitValueTagId, TargetDefinitionId)
VALUES     (-4, 2, 12, 2, 13, 2, 7, 2, 14, -3)

SET IDENTITY_INSERT TargetDefinitionReadWriteTagConfiguration OFF

INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted],
    [OperationalModeId]
)
VALUES
(
    'TestData Target 1',
    100,
    20,
    100,
    20,
    1,
    1,
    100,
    1,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    2,          -- Status = Approved
    2,
    @UnitLevelFloc2,
    1,
    '2005/1/1',
    0,
    12,
    ' ',
    1,

    0,         -- AlertRequired
    0,          -- RequiresResponseWhenAlerted
    2
)

INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    'TestData Target 2',
    null,
    21,
    100,
    null,
    1,
    1,
    100,
    1,
    50,     -- Target value
    0,      -- Target value type
    50,     -- Gap
    1,      -- Status (Pending)
    1,      -- RequiresApproval
    0,      -- IsActive
    1,
    @UnitLevelFloc4,
    1,
    '2005/1/1',
    0,
    13,
    ' ',
    1,
    
    1,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    'TestData Target 19',
    102,
    null,
    100,
    20,
    null,
    1,
    100,
    1,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc2,
    1,
    '2005/1/1',
    0,
    14,
    ' ',
    2,

    1,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinitionState] VALUES(@@IDENTITY, 1, null)

INSERT INTO [dbo].[TargetDefinition](
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    'TestData Target 3',
    103,
    23,
    null,
    20,
    1,
    null,
    100,
    1,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc3,
    1,
    '2005/1/1',
    0,
    15,
    'This is a description',
    1,

    0,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinitionState] VALUES(@@IDENTITY, 1, null)


INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    'TestData Target 4',
    104,
    null,
    null,
    null,
    1,
    null,
    null,
    null,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc1,
    1,
    '2005/1/19',
    0,
    16,			-- schedule ID
    ' ',
    1,

    0,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    'TestData Target 6',
    104,
    null,
    null,
    null,
    1,
    null,
    null,
    null,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc1,
    1,
    '2005/1/5',
    0,
    39,	-- schedule ID
    'Recurring Weekly',
    1,

    1,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinitionState] VALUES(@@IDENTITY, 1, null)

INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    'TestData Target 7',
    104,
    null,
    null,
    null,
    1,
    null,
    null,
    null,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc1,
    1,
    '2005/1/6',
    0,
    40,
    'Recurring Monthly Based On Day Of Month',
    2,

    1,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 


INSERT INTO [dbo].[TargetDefinition]
    (
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    'TestData Target 8',
    104,
    null,
    null,
    null,
    1,
    null,
    null,
    null,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc1,
    1,
    '2005/1/7',
    0,
    41,
    'Recurring Monthly Based On Day Of Month',
    2,

    0,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted]
)
VALUES
(
    'TestData Target 9',
    104,
    null,
    null,
    null,
    1,
    null,
    null,
    null,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc1,
    1,
    '2005/1/8',
    0,
    42,
    'Recurring Monthly Based On Day Of Week',
    2,

    1,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted])
VALUES
(
    'TestData Target 10',
    104,
    null,
    null,
    null,
    1,
    null,
    null,
    null,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc1,
    1,
    '2005/1/9',
    0,
    43,
    'Recurring Monthly Based On Day Of Week',
    2,

    1,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinitionState] VALUES(@@IDENTITY, 1, null)
	
INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted])
VALUES
(
    'TestData Target 11',
    104,
    null,
    null,
    null,
    1,
    null,
    null,
    null,
    50,         -- Target
    0,          -- Target value type
    50,
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc1,
    1,
    '2005/1/10',
    0,
    44,
    'Recurring Hourly',
    2,

    0,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 
INSERT INTO [dbo].[TargetDefinitionState] VALUES(@@IDENTITY, 1, null)


INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [RequiresApproval],
    [IsActive],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted])
VALUES
(
    'TestData Target 12',
    104,
    null,
    null,
    null,
    1,
    null,
    null,
    null,
    50,         -- Target
    0,          -- Target value type
    50,
    1,          -- Status (Pending)
    1,          -- RequiresApproval
    0,          -- IsActive
    1,
    @UnitLevelFloc1,
    1,
    '2005/1/11',
    0,
    45,
    'Recurring By Minute',
    2,

    1,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
) 

INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],

    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],

    [GapUnitValue],
    [TargetDefinitionStatusID],
    [TagID],
    [FunctionalLocationID],

    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],

    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted])
VALUES
(
    'TestData Target 13',
    50,
    10,
    100,
    0,

    1,
    1,
    100,
    1,
    50,         -- Target
    0,          -- Target value type

    50,
    2,      -- Status (Approved)
    2,
    @UnitLevelFloc2,

    1,
    '2005/1/1',
    0,
    46,
    ' ',

    1,

    0,         -- AlertRequired
    0         -- RequiresResponseWhenAlerted
)



-- 
-- Duplicate name in target definition
-- 

INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted],
    [OperationalModeId]
)
VALUES
(
    'TestData Target Duplicate',
    100,
    20,
    100,
    20,
    1,
    1,
    100,
    1,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    2,          -- Status = Approved
    2,
    @UnitLevelFloc2,
    1,
    '2005/1/1',
    0,
    47,
    ' ',
    1,

    0,         -- AlertRequired
    0,          -- RequiresResponseWhenAlerted
    2
)
INSERT INTO [dbo].[TargetDefinition]
(
    [Name],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetDefinitionValue],
    [TargetValueTypeId],
    [GapUnitValue],
    [TargetDefinitionStatusID],
    [TagID],
    [FunctionalLocationID],
    LastModifiedUserId,
    LastModifiedDateTime,
    [Deleted],
    [ScheduleID],
    [Description],
    [TargetCategoryID],
    
    [AlertRequired],
    [RequiresResponseWhenAlerted],
    [OperationalModeId]
)
VALUES
(
    'TestData Target Duplicate',
    100,
    20,
    100,
    20,
    1,
    1,
    100,
    1,
    50,         -- Target value
    0,          -- Target value type
    50,         -- Gap
    2,          -- Status = Approved
    2,
    @UnitLevelFloc2,
    1,
    '2005/1/1',
    0,
    48,
    ' ',
    1,

    0,         -- AlertRequired
    0,          -- RequiresResponseWhenAlerted
    2
)

-- Add a default ReadWrite Tag Configuration for all the TargetDefinitions that don't have one yet.
DECLARE @TargetDefinitionId BIGINT

DECLARE TargetDefIdCursor CURSOR FOR
  Select td.Id From TargetDefinition td
  Where NOT Exists (Select * From TargetDefinitionReadWriteTagConfiguration where TargetDefinitionId = td.Id)
OPEN TargetDefIdCursor

FETCH NEXT From TargetDefIdCursor INTO @TargetDefinitionId

WHILE (@@FETCH_STATUS = 0)
BEGIN
  INSERT INTO dbo.TargetDefinitionReadWriteTagConfiguration 
    (MaxDirectionId, MinDirectionId, TargetDirectionId, GapUnitValueDirectionId, TargetDefinitionId)
    VALUES(0,0,0,0,@TargetDefinitionId)
    FETCH NEXT FROM TargetDefIdCursor INTO @TargetDefinitionId
END

CLOSE TargetDefIdCursor
DEALLOCATE TargetDefIdCursor

INSERT INTO TargetDefinitionState (
  TargetDefinitionId, 
  ExceedingBoundaries, 
  LastSuccessfulTagAccess)
  (
    SELECT td.[Id], 0, null 
    FROM 
      dbo.TargetDefinition td 
    WHERE NOT EXISTS (
        SELECT * From TargetDefinitionState where TargetDefinitionId = td.id)
  )