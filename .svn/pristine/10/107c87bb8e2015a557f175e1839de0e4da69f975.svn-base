DECLARE @FLOC_ID BIGINT;
DECLARE @FLOC_SITE_ID BIGINT;
DECLARE @FLOC_CHAR VARCHAR(10);
DECLARE @SCHEDULE_ID BIGINT;
DECLARE @AID_ID BIGINT;
DECLARE @RECURRING_DAILY_ID BIGINT;

SET @RECURRING_DAILY_ID = 3;

DECLARE @PROCESS_CATEGORY BIGINT;
DECLARE @EHS_CATEGORY BIGINT;
DECLARE @PRODUCTION_CATEGORY BIGINT;
DECLARE @EQUIPMENT_CATEGORY BIGINT;
DECLARE @ROUTINE_CATEGORY BIGINT;

DECLARE @MANUAL_SOURCE BIGINT;
DECLARE @SAP_SOURCE BIGINT;
DECLARE @TARGET_SOURCE BIGINT;

SET @MANUAL_SOURCE = 0;
SET @SAP_SOURCE = 1;
SET @TARGET_SOURCE = 2;

DECLARE @PENDING BIGINT;
DECLARE @APPROVED BIGINT;

SET @PENDING = 0;
SET @APPROVED = 1;

DECLARE @START_31_DAYS_AGO AS DATETIME;
DECLARE @END_31_DAYS_AGO AS DATETIME;

SET @START_31_DAYS_AGO = CONVERT(DATETIME, CONVERT(char(10), GetDate() - 31, 110) + ' 10:00:00.000');
SET @END_31_DAYS_AGO = DATEADD(dd, 1, CONVERT(DATETIME, CONVERT(char(10), GetDate() - 31, 110) + ' 20:00:00.000'));


DECLARE FLOC_ID_CURSOR CURSOR
FOR
    SELECT
        Id
    FROM
        FunctionalLocation
    WHERE
		(
			FullHierarchy like 'SR1-PLT2-%'
			or
			FullHierarchy like 'SR1-PLT3-%'
			or
			FullHierarchy like 'DN1-3003-%'
		)
		and [Level] = 3
		and (SiteId = 1 or SiteId = 2);

OPEN FLOC_ID_CURSOR;

FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;

DECLARE @level3_floc_id bigint

WHILE (@@FETCH_STATUS <> -1)
BEGIN
    IF (@@FETCH_STATUS <> -2)
    BEGIN
       SELECT
            @level3_floc_id = COALESCE(fa.Id, f.Id),
            @FLOC_SITE_ID = f.SiteId
        FROM
            FunctionalLocation f
			LEFT OUTER JOIN FunctionalLocationAncestor a on a.Id = f.Id and a.AncestorLevel = 3
			LEFT OUTER JOIN FunctionalLocation fa on fa.Id = a.AncestorId
        WHERE
            f.Id = @FLOC_ID;

		select 
			--f.fullhierarchy, a.fullhierarchy,
			@FLOC_CHAR = SUBSTRING(f.FullHierarchy, len(a.FullHierarchy) + 2, len(f.FullHierarchy)-len(a.FullHierarchy)-1)
		from 
			functionallocation f
			inner join dbo.FunctionalLocationAncestor 
				on f.Id = dbo.FunctionalLocationAncestor.Id
			inner join dbo.FunctionalLocation a 
				on a.Id = dbo.FunctionalLocationAncestor.AncestorId
			where 
				f.[Level] = a.[Level] + 1 and 
				f.Id = @level3_floc_id
	
		Select @PROCESS_CATEGORY = id from BusinessCategory where siteid = @FLOC_SITE_ID and name = 'Unit Guideline / Process';
		Select @EHS_CATEGORY = id from BusinessCategory where siteid = @FLOC_SITE_ID and name = 'Environmental / Safety';
		Select @PRODUCTION_CATEGORY = id from BusinessCategory where siteid = @FLOC_SITE_ID and name = 'Production';
		Select @EQUIPMENT_CATEGORY = id from BusinessCategory where siteid = @FLOC_SITE_ID and name = 'Equipment / Mechanical';
		Select @ROUTINE_CATEGORY = id from BusinessCategory where siteid = @FLOC_SITE_ID and name = 'Routine Activity';

        --
        -- Clean suction screens definition
        --
        INSERT INTO Schedule
        (
            LastModifiedDateTime,
            ScheduleTypeId,
            StartDateTime,
            EndDateTime,
            FromTime,
            ToTime,
            DailyFrequency,
            Deleted,
            SiteId
        )
        VALUES
        (
            GetDate(),                      -- LastModifiedDateTime
            @RECURRING_DAILY_ID,            -- ScheduleTypeId
            '2006-03-01 00:00:00.000',      -- StartDateTime
            NULL,                           -- EndDateTime
            '09:00',                        -- FromTime
            '14:00',                        -- ToTime
            1,                              -- DailyFrequency
            0,                              -- Deleted
            @FLOC_SITE_ID                   -- SiteID
        );

        SELECT @SCHEDULE_ID = @@IDENTITY;

        INSERT INTO ActionItemDefinition
        (
            [Name],
            [BusinessCategoryId],
            [ActionItemDefinitionStatusId],
            [ScheduleId],
            [Active],
            [RequiresApproval],
            [ResponseRequired],
            [Description],
			[CreateAnActionItemForEachFunctionalLocation],
            [SourceId],
            [SapOperationId],
            [LastModifiedUserId],
            [LastModifiedDateTime],
			[CreatedByUserId],
            [CreatedDateTime],
            [Deleted]
        )
        VALUES
        (
            'Clean suction screens ' + @FLOC_CHAR,  -- Name
            @PROCESS_CATEGORY,                      -- BusinessCategoryId
            @APPROVED,                              -- ActionItemDefinitionStatusId
            @SCHEDULE_ID,                           -- ScheduleId
            1,                                      -- Active
            0,                                      -- RequiresApproval
            0,                                      -- ResponseRequired
            'Clean suction screens',                -- Description
			1,
            @MANUAL_SOURCE,                         -- SourceId
            NULL,                                   -- SapOperationId
            1,                                      -- LastModifiedUserId
            GetDate(),                              -- LastModifiedDateTime
            1,                                      -- CreatedByUserId
            GetDate(),                              -- CreatedDateTime
            0                                       -- Deleted
        );

        SELECT @AID_ID = max(Id) FROM ActionItemDefinition;

        INSERT INTO ActionItemDefinitionFunctionalLocation
        (
            [ActionItemDefinitionId],
            [FunctionalLocationId]
        )
        VALUES
        (
            @AID_ID,
            @FLOC_ID
        );

       --
       -- Pressure survey definition
       --
        INSERT INTO Schedule
        (
            LastModifiedDateTime,
            ScheduleTypeId,
            StartDateTime,
            EndDateTime,
            FromTime,
            ToTime,
            DailyFrequency,
            Deleted,
            SiteId
        )
        VALUES
        (
            GetDate(),                      -- LastModifiedDateTime
            @RECURRING_DAILY_ID,            -- ScheduleTypeId
            '2006-03-01 00:00:00.000',      -- StartDateTime
            NULL,                           -- EndDateTime
            '09:00',                        -- FromTime
            '14:00',                        -- ToTime
            1,                              -- DailyFrequency
            0,                              -- Deleted
            @FLOC_SITE_ID                   -- SiteID
        );
   
        SELECT @SCHEDULE_ID = @@IDENTITY;

        INSERT INTO ActionItemDefinition
        (
            [Name],
            [BusinessCategoryId],
            [ActionItemDefinitionStatusId],
            [ScheduleId],
            [Active],
            [RequiresApproval],
            [ResponseRequired],
            [Description],
			[CreateAnActionItemForEachFunctionalLocation],
            [SourceId],
            [SapOperationId],
            [LastModifiedUserId],
            [LastModifiedDateTime],
			[CreatedByUserId],
            [CreatedDateTime],
            [Deleted])    
            VALUES('Pressure survey ' + @FLOC_CHAR,     -- Name
            @PROCESS_CATEGORY,                          -- BusinessCategoryId
            @APPROVED,                                  -- ActionItemDefinitionStatusId
            @SCHEDULE_ID,                               -- ScheduleId
            0,                                          -- Active
            0,                                          -- RequiresApproval
            0,                                          -- ResponseRequired
            'Pressure survey',                          -- Description
			1,
            0,                                          -- SourceId
            NULL,                                       -- SapOperationId
            1,                                          -- LastModifiedUserId
            GetDate(),                                  -- LastModifiedDateTime
			1,                                          -- CreatedByUserId
            GetDate(),                                  -- CreatedDateTime
            0                                           -- Deleted
        );

        SELECT @AID_ID = max(Id) FROM ActionItemDefinition;

        INSERT INTO ActionItemDefinitionFunctionalLocation
        (
            [ActionItemDefinitionId],
            [FunctionalLocationId]
        )
        VALUES
        (
            @AID_ID,
            @FLOC_ID
        );

        --
        -- Take a sample definition
        --
        INSERT INTO Schedule
        (
            LastModifiedDateTime,
            ScheduleTypeId,
            StartDateTime,
            EndDateTime,
            FromTime,
            ToTime,
            DailyFrequency,
            Deleted,
            SiteId
        )
        VALUES
        (
            GetDate(),                  -- LastModifiedDateTime
            @RECURRING_DAILY_ID,        -- ScheduleTypeId
            '2006-03-01 00:00:00.000',  -- StartDateTime
            NULL,                       -- EndDateTime
            '09:00',                    -- FromTime
            '14:00',                    -- ToTime
            1,                          -- DailyFrequency
            0,                          -- Deleted
            @FLOC_SITE_ID               -- SiteID
        );

        SELECT @SCHEDULE_ID = @@IDENTITY;

        INSERT INTO ActionItemDefinition
        (
            [Name],
            [BusinessCategoryId],
            [ActionItemDefinitionStatusId],
            [ScheduleId],
            [Active],
            [RequiresApproval],
            [ResponseRequired],
            [Description],
			[CreateAnActionItemForEachFunctionalLocation],
            [SourceId],
            [SapOperationId],
            [LastModifiedUserId],
            [LastModifiedDateTime],
			[CreatedByUserId],
            [CreatedDateTime],
            [Deleted]
        )
        VALUES
        (
            'Take a sample ' + @FLOC_CHAR,  -- Name
            @PROCESS_CATEGORY,              -- BusinessCategoryId
            @PENDING,                       -- ActionItemDefinitionStatusId
            @SCHEDULE_ID,                   -- ScheduleId
            0,                              -- Active
            1,                              -- RequiresApproval
            0,                              -- ResponseRequired
            'Take a sample',                -- Description
			1,
            @MANUAL_SOURCE,                 -- SourceId
            NULL,                           -- SapOperationId
            1,                              -- LastModifiedUserId
            GetDate(),                      -- LastModifiedDateTime
			1,                              -- CreatedByUserId
            GetDate(),                      -- CreatedDateTime
            0                               -- Deleted
        );

        SELECT @AID_ID = max(Id) FROM ActionItemDefinition;

        INSERT INTO ActionItemDefinitionFunctionalLocation
        (
            [ActionItemDefinitionId],
            [FunctionalLocationId]
        )
        VALUES
        (
            @AID_ID,
            @FLOC_ID
        );

        --
        -- SAP M&R definition
        --
       INSERT INTO Schedule
       (
            LastModifiedDateTime,
            ScheduleTypeId,
            StartDateTime,
            EndDateTime,
            FromTime,
            ToTime,
            DailyFrequency,
            Deleted,
            SiteId
        )
       VALUES
       (
            GetDate(),                  -- LastModifiedDateTime
            @RECURRING_DAILY_ID,        -- ScheduleTypeId
            '2006-03-01 00:00:00.000',  -- StartDateTime
            NULL,                       -- EndDateTime
            '09:00',                    -- FromTime
            '14:00',                    -- ToTime
            1,                          -- DailyFrequency
            0,                          -- Deleted
            @FLOC_SITE_ID               -- SiteID
        );

        SELECT @SCHEDULE_ID = @@IDENTITY;

        INSERT INTO ActionItemDefinition
        (
            [Name],
            [BusinessCategoryId],
            [ActionItemDefinitionStatusId],
            [ScheduleId],
            [Active],
            [RequiresApproval],
            [ResponseRequired],
            [Description],
			[CreateAnActionItemForEachFunctionalLocation],
            [SourceId],
            [SapOperationId],
            [LastModifiedUserId],
            [LastModifiedDateTime],
			[CreatedByUserId],
            [CreatedDateTime],
            [Deleted]
        )
        VALUES
        (
            'SAP M&R ' + @FLOC_CHAR,        -- Name
            @EQUIPMENT_CATEGORY,            -- BusinessCategoryId
            @APPROVED,                      -- ActionItemDefinitionStatusId
            @SCHEDULE_ID,                   -- ScheduleId
            1,                              -- Active
            0,                              -- RequiresApproval
            0,                              -- ResponseRequired
            'M&R - Equpiment Prep for Maintenance as per WON12345',        -- Description
			1,
            @SAP_SOURCE,                    -- SourceId
            NULL,                           -- SapOperationId
            1,                              -- LastModifiedUserId
            GetDate(),                      -- LastModifiedDateTime
			1,                              -- CreatedByUserId
            GetDate(),                      -- CreatedDateTime
            0                               -- Deleted
        );

        SELECT @AID_ID = max(Id) FROM ActionItemDefinition;

        INSERT INTO ActionItemDefinitionFunctionalLocation
        (
            [ActionItemDefinitionId],
            [FunctionalLocationId]
        )
        VALUES
        (
            @AID_ID,
            @FLOC_ID
        );

       --
       -- SAP M&D definition
       --
       INSERT INTO Schedule
       (
            LastModifiedDateTime,
            ScheduleTypeId,
            StartDateTime,
            EndDateTime,
            FromTime,
            ToTime,
            DailyFrequency,
            Deleted,
            SiteId
        )
       VALUES
       (
            GetDate(),                  -- LastModifiedDateTime
            @RECURRING_DAILY_ID,        -- ScheduleTypeId
            '2006-03-01 00:00:00.000',  -- StartDateTime
            NULL,                       -- EndDateTime
            '09:00',                    -- FromTime
            '14:00',                    -- ToTime
            1,                          -- DailyFrequency
            0,                          -- Deleted
            @FLOC_SITE_ID               -- SiteID
        );

        SELECT @SCHEDULE_ID = @@IDENTITY;

        INSERT INTO ActionItemDefinition
        (
            [Name],
            [BusinessCategoryId],
            [ActionItemDefinitionStatusId],
            [ScheduleId],
            [Active],
            [RequiresApproval],
            [ResponseRequired],
            [Description],
			[CreateAnActionItemForEachFunctionalLocation],
            [SourceId],
            [SapOperationId],
            [LastModifiedUserId],
            [LastModifiedDateTime],
			[CreatedByUserId],
            [CreatedDateTime],
            [Deleted]
        )
        VALUES
        (
            'SAP M&D ' + @FLOC_CHAR,        -- Name
            @PRODUCTION_CATEGORY,           -- BusinessCategoryId
            @APPROVED,                      -- ActionItemDefinitionStatusId
            @SCHEDULE_ID,                   -- ScheduleId
            1,                              -- Active
            0,                              -- RequiresApproval
            0,                              -- ResponseRequired
            'M&D - Loading Action',         -- Description
			1,
            @SAP_SOURCE,                    -- SourceId
            NULL,                           -- SapOperationId
            1,                              -- LastModifiedUserId
            GetDate(),                      -- LastModifiedDateTime
			1,                              -- CreatedByUserId
            GetDate(),                      -- CreatedDateTime
            0                               -- Deleted
        );

        SELECT @AID_ID = max(Id) FROM ActionItemDefinition;

        INSERT INTO ActionItemDefinitionFunctionalLocation ([ActionItemDefinitionId], [FunctionalLocationId])
        VALUES (@AID_ID, @FLOC_ID);

        --
        -- SAP EH&S definition
        --   
        INSERT INTO Schedule
        (
            LastModifiedDateTime,
            ScheduleTypeId,
            StartDateTime,
            EndDateTime,
            FromTime,
            ToTime,
            DailyFrequency,
            Deleted,
            SiteId
        )
       VALUES
       (
            GetDate(),                      -- LastModifiedDateTime
            @RECURRING_DAILY_ID,            -- ScheduleTypeId
            '2006-03-01 00:00:00.000',      -- StartDateTime
            NULL,                           -- EndDateTime
            '09:00',                        -- FromTime
            '14:00',                        -- ToTime
            1,                              -- DailyFrequency
            0,                              -- Deleted
            @FLOC_SITE_ID                   -- SiteID
        );

        SELECT @SCHEDULE_ID = @@IDENTITY;

        INSERT INTO ActionItemDefinition
        (
            [Name],
            [BusinessCategoryId],
            [ActionItemDefinitionStatusId],
            [ScheduleId],
            [Active],
            [RequiresApproval],
            [ResponseRequired],
            [Description],
			[CreateAnActionItemForEachFunctionalLocation],
            [SourceId],
            [SapOperationId],
            [LastModifiedUserId],
            [LastModifiedDateTime],
			[CreatedByUserId],
            [CreatedDateTime],
            [Deleted]
        )
        VALUES
        (
            'SAP M&D ' + @FLOC_CHAR,    -- Name
            @EHS_CATEGORY,              -- BusinessCategoryId
            @APPROVED,                  -- ActionItemDefinitionStatusId
            @SCHEDULE_ID,               -- ScheduleId
            1,                          -- Active
            0,                          -- RequiresApproval
            0,                          -- ResponseRequired
            'EH&S - MOC Action',        -- Description
			1,
            @SAP_SOURCE,                -- SourceId
            NULL,                       -- SapOperationId
            1,                          -- LastModifiedUserId
            GetDate(),                  -- LastModifiedDateTime
			1,                          -- CreatedByUserId
            GetDate(),                  -- CreatedDateTime
            0                           -- Deleted
        );

        SELECT @AID_ID = max(Id) FROM ActionItemDefinition;

        INSERT INTO ActionItemDefinitionFunctionalLocation
        (
            [ActionItemDefinitionId],
            [FunctionalLocationId]
        )
        VALUES
        (
            @AID_ID,
            @FLOC_ID
        );
        
        -- add "Old" Action Item
        INSERT INTO ActionItem
        (
			[ResponseRequired],
			[ActionItemStatusId],
			[PriorityId],
			[BusinessCategoryId],
			[Description],
			[StartDateTime],
			[EndDateTime],
			[ShiftAdjustedEndDateTime],
			[SourceId],
			[LastModifiedUserId],
			[LastModifiedDateTime],
			[createdByScheduleTypeId],
			[Deleted],
			[Name]
        )
		VALUES
		(
		    0,
		    1,
		    1,
		    @PROCESS_CATEGORY,
		    'Old Action Item',
		    @START_31_DAYS_AGO,
			@END_31_DAYS_AGO,
			'9999-12-31 23:59:59.997',
			0,
			1,
			GetDate(),
			1,
			0,
			'Old Action Item'
	    );
	    
		insert into ActionItemFunctionalLocation values (IDENT_CURRENT('ActionItem'), @FLOC_ID);

    END;

    FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;
END;

CLOSE FLOC_ID_CURSOR;
DEALLOCATE FLOC_ID_CURSOR;