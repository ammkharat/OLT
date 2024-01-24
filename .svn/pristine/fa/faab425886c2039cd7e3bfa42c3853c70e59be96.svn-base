DECLARE @ActionItemDefinitionKEY AS BIGINT;
DECLARE @UnitLevelFloc AS BIGINT;
select @UnitLevelFloc = id from functionallocation where fullhierarchy = 'SR1-OFFS-BDOF';

declare @site_id bigint;
select @site_id = siteid from functionallocation where id = @UnitLevelFloc;

declare @business_category_id bigint;
select @business_category_id = min(id ) from businesscategory b where b.siteid = @site_id;


SET IDENTITY_INSERT ActionItemDefinition ON

INSERT INTO ActionItemDefinition
(
	Id,
    [Name],
    ScheduleId,
    BusinessCategoryId,
    ActionItemDefinitionStatusId,
    Description,
	CreateAnActionItemForEachFunctionalLocation,
    LastModifiedUserId,
    LastModifiedDateTime,
	CreatedByUserId,
	CreatedDateTime
) 
VALUES
(
	1,
    'Name 1',
    2,
    @business_category_id,
    1,
    'First Action Item, Do your work!',
	1,
    1,
    GetDate(),
	1,
	GetDate()
);
SET @ActionItemDefinitionKEY = @@IDENTITY;
INSERT INTO ActionItemDefinitionFunctionalLocation (ActionItemDefinitionId, FunctionalLocationId) VALUES (@ActionItemDefinitionKEY, @UnitLevelFloc);


-- Action item definition to add comments to
INSERT INTO ActionItemDefinition (
    Id,
    [Name],
    ScheduleId,
    BusinessCategoryId,
    ActionItemDefinitionStatusId, 
    Description, 
	CreateAnActionItemForEachFunctionalLocation,
    LastModifiedUserId, 
    LastModifiedDateTime,
	CreatedByUserId,
	CreatedDateTime,
    Deleted
)
VALUES
(
    20,                                 -- Id
    'Name 20',                          -- Name 
    1,                                  -- ScheduleId
    @business_category_id,                                  -- BusinessCategoryId
    1,                                  -- ActionItemDefinitionStatusId
    'Id = 20 - for adding comments to', -- Description
	1,
    2,                                  -- LastModifiedUserId
    GetDate(),                          -- LastModifiedDateTime
	2,                                  -- CreatedByUserId
	GetDate(),                          -- CreatedDateTime
    0                                   -- Deleted
);

INSERT INTO ActionItemDefinitionFunctionalLocation (ActionItemDefinitionId, FunctionalLocationId) VALUES (20, 27561);

-- Action item definition with 2 comments
INSERT INTO ActionItemDefinition (
    Id,
    [Name],
    ScheduleId,
    BusinessCategoryId,
    ActionItemDefinitionStatusId, 
    Description, 
	CreateAnActionItemForEachFunctionalLocation,
    LastModifiedUserId, 
    LastModifiedDateTime,
	CreatedByUserId,
	CreatedDateTime,	
    Deleted,
    OperationalModeId,
	WorkAssignmentId
)
VALUES
(
    21,                                 -- Id
    'Name 21',                          -- Name 
    1,                                  -- ScheduleId
    @business_category_id,                                  -- BusinessCategoryId
    1,                                  -- ActionItemDefinitionStatusId
    'Id = 21 - has 2 comments',         -- Description
	1,
    2,                                  -- LastModifiedUserId
    '2006-01-25 19:00:00',              -- LastModifiedDateTime
	2,                                  -- CreatedByUserId
    '2006-01-25 19:00:00',              -- CreatedDateTime
    0,                                  -- Deleted
    1,									-- OperationalModeId,
	1									-- Assignment Id
);

INSERT INTO [ActionItemDefinitionComment] ([ActionItemDefinitionId], [CommentId]) VALUES (21, 3);
INSERT INTO [ActionItemDefinitionComment] ([ActionItemDefinitionId], [CommentId]) VALUES (21, 4);
INSERT INTO ActionItemDefinitionFunctionalLocation (ActionItemDefinitionId, FunctionalLocationId) VALUES (21, @UnitLevelFloc);

--
-- ActionItemDefinition with an ActionItem linking to it.
-- For testing the story on going to ActionItemDefinition from ActionItem
--
INSERT INTO ActionItemDefinition
(
    Id,
    [Name],
    ScheduleId,
    BusinessCategoryId,
    ActionItemDefinitionStatusId,
    Active,
    Description, 
	CreateAnActionItemForEachFunctionalLocation,
    LastModifiedUserId, 
    LastModifiedDateTime,
	CreatedByUserId,
	CreatedDateTime,
    SourceId,
    Deleted
)
VALUES
(
    35,                                         -- Id
    'Id = 35 For Linking ActionItem',           -- Name 
    1,                                          -- ScheduleId
    @business_category_id,                                          -- BusinessCategoryId
    1,                                          -- ActionItemDefinitionStatusId
    0,                                          -- Active
    'Id = 35 Used for linking Action Item to it', -- Description
	1,
    2,                                          -- LastModifiedUserId
    GetDate(),                                  -- LastModifiedDateTime
	2,                                          -- CreatedByUserId
    GetDate(),                                  -- CreatedDateTime
    0,                                          -- SourceId
    0                                           -- Deleted
);
INSERT INTO ActionItemDefinitionFunctionalLocation (ActionItemDefinitionId, FunctionalLocationId) VALUES (35, 27561);

SET IDENTITY_INSERT ActionItemDefinition OFF
DBCC CHECKIDENT (ActionItemDefinition, RESEED) 

GO   