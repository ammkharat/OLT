DECLARE @FLOC_ID BIGINT;
DECLARE @FLOC_SITE_ID BIGINT;
DECLARE @SCHEDULE_ID BIGINT;
DECLARE @AID_ID BIGINT;
DECLARE @RECURRING_DAILY_ID BIGINT;

SET @RECURRING_DAILY_ID = 3;

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
		FullHierarchy like 'EX1-P086-%'
		or
		FullHierarchy like 'EX2-P082-%'
		or
		FullHierarchy like 'EX1-P016-%'
		or
		FullHierarchy like 'UP1-P008-%'
		or
		FullHierarchy like 'UP1-P021-%'
		or
		FullHierarchy like 'UP1-P032-%'
		or
		FullHierarchy like 'UP2-P052-%'
		or
		FullHierarchy like 'UP2-P053-%'
		or
		FullHierarchy like 'UP2-P054-%'
		)
        AND [Level]=3
		and SiteId = 3
		AND Deleted=0;

OPEN FLOC_ID_CURSOR;

FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;

WHILE (@@FETCH_STATUS <> -1)
BEGIN
    IF (@@FETCH_STATUS <> -2)
    BEGIN

        SELECT
            @FLOC_SITE_ID = SiteId
        FROM
            FunctionalLocation
        WHERE
            Id = @FLOC_ID;

		declare @PROCESS_CATEGORY bigint;
		Select @PROCESS_CATEGORY = id from BusinessCategory where siteid = @FLOC_SITE_ID and name = 'Unit Guideline / Process';

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
            '2010-08-01 00:00:00.000',      -- StartDateTime
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
            'Safe equipment',                       -- Name
            @PROCESS_CATEGORY,                                      -- BusinessCategoryId
            1,                                      -- ActionItemDefinitionStatusId
            @SCHEDULE_ID,                           -- ScheduleId
            1,                                      -- Active
            0,                                      -- RequiresApproval
            0,                                      -- ResponseRequired
            'Safe equipment for maintenance',       -- Description
			1,
            0,                                      -- SourceId
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
    END;

    FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;
END;

CLOSE FLOC_ID_CURSOR;
DEALLOCATE FLOC_ID_CURSOR;

