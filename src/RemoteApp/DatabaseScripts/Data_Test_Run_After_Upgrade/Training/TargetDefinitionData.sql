DECLARE @FLOC_ID BIGINT;
DECLARE @FLOC_SITE_ID BIGINT;
DECLARE @FLOC_CHAR VARCHAR(10);
DECLARE @SCHEDULE_ID BIGINT;
DECLARE @RECURRING_BY_MINUTE_ID BIGINT;

SET @RECURRING_BY_MINUTE_ID = 8;

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

       --
       -- Freeze warning definition
       --
        INSERT INTO Schedule
        (
            LastModifiedDateTime,
            ScheduleTypeId,
            StartDateTime,
            EndDateTime,
            FROMTime,
            ToTime,
            DailyFrequency,
            Deleted,
            SiteId
        )
        VALUES
        (
            GetDate(),                  -- LastModifiedDateTime
            @RECURRING_BY_MINUTE_ID,    -- ScheduleTypeId
            '2006-03-01 00:00:00.000',  -- StartDateTime
            NULL,                       -- EndDateTime
            '09:00',                    -- FROMTime
            '17:00',                    -- ToTime
            25,                         -- DailyFrequency
            0,                          -- Deleted
            @FLOC_SITE_ID               -- SiteId
        );

        SELECT @SCHEDULE_ID = @@IDENTITY;

        INSERT INTO TargetDefinition
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
            [TargetCategoryID],
            [TagID],
            [FunctionalLocationID],
            [LastModifiedUserId],
            [LastModifiedDateTime],
            [Deleted],
            [GenerateActionItem],
            [Description],
            [ScheduleId],

            [AlertRequired],
            [RequiresApproval],
            [RequiresResponseWhenAlerted],
            [IsActive]
        )
        VALUES
        (
            'Freeze Warning ' + @FLOC_CHAR,     -- Name
            NULL,                               -- NeverToExceedMax
            NULL,                               -- NeverToExceedMin
            NULL,                               -- MaxValue
            0,                                  -- MinValue
            1,                                  -- NeverToExceedMaxFrequency
            1,                                  -- NeverToExceedMinFrequency
            1,                                  -- MaxValueFrequency
            2,                                  -- MinValueFrequency
            NULL,                               -- TargetDefinitionValue
            0,                                  -- TargetValueTypeId
            NULL,                               -- GapUnitValue
            2,                                  -- TargetDefinitionStatusID
            1,                                  -- TargetCategoryID
            8078,                               -- TagID
            @FLOC_ID,                           -- FunctionalLocationID
            1,                                  -- LastModifiedUserId
            GetDate(),                          -- LastModifiedDateTime
            0,                                  -- Deleted
            0,                                  -- GenerateActionItem
            'Warn if ambient air temperature is below freezing',    -- Description
            @SCHEDULE_ID,                       -- ScheduleId
            
            1,                                  -- AlertRequired
            0,                                  -- RequiresApproval
            1,                                  -- RequiresResponseWhenAlerted
            1                                  -- IsActive
        );

		INSERT INTO [dbo].[TargetDefinitionState] VALUES(@@IDENTITY, 1, null)		
		
        --
        -- Hydrocracker definition
        --
        INSERT INTO Schedule
        (
            LastModifiedDateTime,
            ScheduleTypeId,
            StartDateTime,
            EndDateTime,
            FROMTime,
            ToTime,
            DailyFrequency,
            Deleted,
            SiteId
        )
        VALUES
        (
            GetDate(),                  -- LastModifiedDateTime
            @RECURRING_BY_MINUTE_ID,    -- ScheduleTypeId
            '2006-03-01 00:00:00.000',  -- StartDateTime
            NULL,                       -- EndDateTime
            '08:00',                    -- FROMTime
            '22:00',                    -- ToTime
            13,                         -- DailyFrequency
            0,                          -- Deleted
            @FLOC_SITE_ID               -- SiteId
        );

        SELECT @SCHEDULE_ID = @@IDENTITY;

        INSERT INTO TargetDefinition
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
            [TargetCategoryID],
            [TagID],
            [FunctionalLocationID],
            [LastModifiedUserId],
            [LastModifiedDateTime],
            [Deleted],
            [GenerateActionItem],
            [Description],
            [ScheduleId],

            [AlertRequired],
            [RequiresApproval],
            [RequiresResponseWhenAlerted],
            [IsActive]
        )
        VALUES
        (
            'Hydrocracker Charge ' + @FLOC_CHAR,    -- Name
            NULL,                                   -- NeverToExceedMax
            NULL,                                   -- NeverToExceedMin
            3900.0,                                 -- MaxValue
            NULL,                                   -- MinValue
            1,                                      -- NeverToExceedMaxFrequency
            1,                                      -- NeverToExceedMinFrequency
            1,                                      -- MaxValueFrequency
            1,                                      -- MinValueFrequency
            3000.0,                                 -- TargetDefinitionValue
            0,                                      -- TargetValueTypeId
            NULL,                                   -- GapUnitValue
            2,                                      -- TargetDefinitionStatusID
            1,                                      -- TargetCategoryID
            8078,                                   -- TagID
            @FLOC_ID,                               -- FunctionalLocationID
            1,                                      -- LastModifiedUserId
            GetDate(),                              -- LastModifiedDateTime
            0,                                      -- Deleted
            0,                                      -- GenerateActionItem
            'Hydrocracker Charge Rate',             -- Description
            @SCHEDULE_ID,                           -- ScheduleId

            1,                                      -- AlertRequired
            0,                                      -- RequiresApproval
            1,                                      -- RequiresResponseWhenAlerted
            0                                      -- IsActive
        );

		INSERT INTO [dbo].[TargetDefinitionState] VALUES(@@IDENTITY, 1, null)		
		
        --
        -- Plant 2 Crude Charge definition
        --
        INSERT INTO Schedule
        (
            LastModifiedDateTime,
            ScheduleTypeId,
            StartDateTime,
            EndDateTime,
            FROMTime,
            ToTime,
            DailyFrequency,
            Deleted,
            SiteId
        )
        VALUES
        (
            GetDate(),                      -- LastModifiedDateTime
            @RECURRING_BY_MINUTE_ID,        -- ScheduleTypeId
            '2006-03-01 00:00:00.000',      -- StartDateTime
            NULL,                           -- EndDateTime
            '09:00',                        -- FROMTime
            '15:00',                        -- ToTime
            15,                             -- DailyFrequency
            0,                              -- Deleted
            @FLOC_SITE_ID                   -- SiteId
        );
       
        SELECT @SCHEDULE_ID = @@IDENTITY;

        INSERT INTO TargetDefinition
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
            [TargetCategoryID],
            [TagID],
            [FunctionalLocationID],
            [LastModifiedUserId],
            [LastModifiedDateTime],
            [Deleted],
            [GenerateActionItem],
            [Description],
            [ScheduleId],

            [AlertRequired],
            [RequiresApproval],
            [RequiresResponseWhenAlerted],
            [IsActive]
        )
        VALUES
        (
            'OFFS IPPL INLET DENS ' + @FLOC_CHAR,   -- Name
            6900.0,                                 -- NeverToExceedMax
            NULL,                                   -- NeverToExceedMin
            6500.0,                                 -- MaxValue
            NULL,                                   -- MinValue
            1,                                      -- NeverToExceedMaxFrequency
            1,                                      -- NeverToExceedMinFrequency
            1,                                      -- MaxValueFrequency
            1,                                      -- MinValueFrequency
            6000.0,                                 -- TargetDefinitionValue
            0,                                      -- TargetValueTypeId
            NULL,                                   -- GapUnitValue
            2,                                      -- TargetDefinitionStatusID
            1,                                      -- TargetCategoryID
            14930,                                     -- TagID
            @FLOC_ID,                               -- FunctionalLocationID
            1,                                      -- LastModifiedUserId
            GetDate(),                              -- LastModifiedDateTime
            0,                                      -- Deleted
            0,                                      -- GenerateActionItem
            'OFFSITES IPPL INLET DENSITY',            -- Description
            @SCHEDULE_ID,                           -- ScheduleId

            1,                                      -- AlertRequired
            0,                                      -- RequiresApproval
            1,                                      -- RequiresResponseWhenAlerted
            1                                      -- IsActive
        );
		
		INSERT INTO [dbo].[TargetDefinitionState] VALUES(@@IDENTITY, 1, null)				
		
    END;
    FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;
END;

CLOSE FLOC_ID_CURSOR;

DEALLOCATE FLOC_ID_CURSOR;



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