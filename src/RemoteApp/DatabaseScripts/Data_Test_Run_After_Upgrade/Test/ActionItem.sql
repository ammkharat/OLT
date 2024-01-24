DECLARE @ACTION_ITEM_STATUS_CURRENT BIGINT;
DECLARE @ACTION_ITEM_STATUS_COMPLETE BIGINT;
DECLARE @ACTION_ITEM_STATUS_INCOMPLETE BIGINT;
DECLARE @ACTION_ITEM_STATUS_CANNOT_COMPLETE BIGINT;
DECLARE @ACTION_ITEM_STATUS_CLEARED BIGINT;

SET @ACTION_ITEM_STATUS_CURRENT         = 0;
SET @ACTION_ITEM_STATUS_COMPLETE        = 1;
SET @ACTION_ITEM_STATUS_INCOMPLETE      = 2;
SET @ACTION_ITEM_STATUS_CANNOT_COMPLETE = 3;
SET @ACTION_ITEM_STATUS_CLEARED         = 4;

declare @floc_id bigint;
set @floc_id = 24723;

declare @site_id bigint;
select @site_id = siteid from functionallocation where id = @floc_id;

declare @business_category_id bigint;
select @business_category_id = min(id ) from businesscategory b where b.siteid = @site_id;
	

INSERT INTO ActionItem
(
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    [Name]
) 
VALUES
(
    @ACTION_ITEM_STATUS_INCOMPLETE,    -- ActionItemStatusId
    1,                                 -- Priority Normal
    'First Action Item',               -- Description
    1,                                 -- CreatedByScheduleTypeId
    2,                                 -- LastModifiedUserId
    GetDate(),                         -- LastModifiedDateTime
    GetDate(),                         -- StartDateTime
    DATEADD(day, 1, GetDate()),        -- EndDateTime
    @business_category_id,                                 -- BusinessCategoryId
    'Action Item #1'                   -- [Name]
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);

INSERT INTO ActionItem 
( 
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    Name
) 
VALUES
(
    @ACTION_ITEM_STATUS_COMPLETE,    -- ActionItemStatusId
    1,                               -- Priority Normal
    'Second Action Item',            -- Description
    1,                               -- CreatedByScheduleTypeId
    2,                               -- LastModifiedUserId
    GetDate(),                       -- LastModifiedDateTime
    GetDate(),                       -- StartDateTime
    NULL,                            -- EndDateTime
    @business_category_id,                               -- BusinessCategoryId
    'Action Item #2'                 -- [Name]
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);

INSERT INTO ActionItem
( 
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    Name
) 
VALUES 
(
    @ACTION_ITEM_STATUS_CANNOT_COMPLETE,    -- ActionItemStatusId
    1,                                      -- Priority Normal
    'Third Action Item',                    -- Description
    2,                                      -- CreatedByScheduleTypeId
    2,                                      -- LastModifiedUserId
    GetDate(),                              -- LastModifiedDateTime
    GetDate(),                              -- StartDateTime
    NULL,                                   -- EndDateTime
    @business_category_id,                                      -- BusinessCategoryId
    'Action Item #3'                        -- [Name]
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);

INSERT INTO ActionItem 
( 
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    Name
)  
VALUES 
(
    @ACTION_ITEM_STATUS_CURRENT,        -- ActionItemStatusId
    1,                                  -- Priority Normal
    'Scheduled For Later this shift',   -- Description
    1,                                  -- CreatedByScheduleTypeId
    2,                                  -- LastModifiedUserId
    GetDate(),                          -- LastModifiedDateTime
    DATEADD(hour, 3, GetDate()),        -- StartDateTime
    DATEADD(hour, 5, GetDate()),        -- EndDateTime
    @business_category_id,                                  -- BusinessCategoryId
    'Action Item #4'                    -- [Name]
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);

INSERT INTO ActionItem 
( 
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    Name
)
VALUES 
(
    @ACTION_ITEM_STATUS_CURRENT,    -- ActionItemStatusId
    1,                              -- Priority Normal
    'Late schedule re-occuring',    -- Description
    2,                              -- CreatedByScheduleTypeId
    2,                              -- LastModifiedUserId
    GetDate(),                      -- LastModifiedDateTime
    DATEADD(hour, -7, GetDate()),   -- StartDateTime
    DATEADD(hour, -5, GetDate()),   -- EndDateTime
    @business_category_id,                              -- BusinessCategoryId
    'Action Item #5'                -- [Name]
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);

INSERT INTO ActionItem
( 
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    Name
)  
VALUES 
(
    @ACTION_ITEM_STATUS_COMPLETE,   -- ActionItemStatusId
    1,                              -- Priority Normal
    'Completed re-occurring',       -- Description
    2,                              -- CreatedByScheduleTypeId
    2,                              -- LastModifiedUserId
    GetDate(),                      -- LastModifiedDateTime
    GetDate(),                      -- StartDateTime
    NULL,                           -- EndDateTime
    @business_category_id,                              -- BusinessCategoryId
    'Action Item #6'                -- [Name]
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);

INSERT INTO ActionItem 
( 
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    Name
)  
VALUES 
(
    @ACTION_ITEM_STATUS_INCOMPLETE, -- ActionItemStatusId
    1,                              -- Priority Normal
    'Incomplete',                   -- Description
    1,                              -- CreatedByScheduleTypeId
    2,                              -- LastModifiedUserId
    GetDate(),                      -- LastModifiedDateTime
    GetDate(),                      -- StartDateTime
    NULL,                           -- EndDateTime
    @business_category_id,                              -- BusinessCategoryId
    'Action Item #7'                -- [Name]
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);

INSERT INTO ActionItem
( 
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    Name
)  
VALUES 
(
    @ACTION_ITEM_STATUS_CANNOT_COMPLETE,    -- ActionItemStatusId
    1,                                      -- Priority Normal
    'Cannot complete',                      -- Description
    1,                                      -- CreatedByScheduleTypeId
    2,                                      -- LastModifiedUserId
    GetDate(),                              -- LastModifiedDateTime
    GetDate(),                              -- StartDateTime
    NULL,                                   -- EndDateTime
    @business_category_id,                                      -- BusinessCategoryId
    'Action Item #8'                        -- [Name]
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);

INSERT INTO ActionItem
(
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    [Name],
    CreatedByActionItemDefinitionId
) 
VALUES
(
    @ACTION_ITEM_STATUS_INCOMPLETE,                                 -- ActionItemStatusId
    1,                                                              -- Priority Normal
    'Action Item With Created By Action Item Definition Id = 35',   -- Description
    1,                                                              -- CreatedByScheduleTypeId
    2,                                                              -- LastModifiedUserId
    GetDate(),                                                      -- LastModifiedDateTime
    GetDate(),                                                      -- StartDateTime
    DATEADD(day, 1, GetDate()),                                     -- EndDateTime
    @business_category_id,                                                              -- BusinessCategoryId
    'AI With Created By AID 35',                                    -- [Name]
    35                                                              -- CreatedByActionItemDefinitionId
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);

INSERT INTO ActionItem
(
    ActionItemStatusId,
    PriorityId,
    Description,
    CreatedByScheduleTypeId,
    LastModifiedUserId,
    LastModifiedDateTime,
    StartDateTime,
    EndDateTime,
    BusinessCategoryId,
    [Name],
    CreatedByActionItemDefinitionId
) 
VALUES
(
    @ACTION_ITEM_STATUS_INCOMPLETE,                                 -- ActionItemStatusId
    1,                                                              -- Priority Normal
    'Action Item With Created By AID Id = 36 But AID is not in the GRID',   -- Description
    1,                                                              -- CreatedByScheduleTypeId
    2,                                                              -- LastModifiedUserId
    GetDate(),                                                      -- LastModifiedDateTime
    GetDate(),                                                      -- StartDateTime
    DATEADD(day, 1, GetDate()),                                     -- EndDateTime
    @business_category_id,                                                              -- BusinessCategoryId
    'AI With Created By AID 36',                                    -- [Name]
    35                                                              -- CreatedByActionItemDefinitionId
);

insert into ActionItemFunctionalLocation values (@@IDENTITY, @floc_id);
