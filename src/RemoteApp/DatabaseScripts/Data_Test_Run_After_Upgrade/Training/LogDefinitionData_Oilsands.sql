DECLARE @FLOC_ID BIGINT;
DECLARE @SCHEDULE_ID BIGINT;
DECLARE @RECURRING_DAILY_ID BIGINT;
DECLARE @NEXT_ID CHAR(12);

DECLARE @SOME_DAYS_AGO AS DATETIME;
SET @SOME_DAYS_AGO = CONVERT(DATETIME, CONVERT(char(10), GetDate() - 2, 110) + ' 10:00:00.000');

DECLARE @DA_SHIFT_ID AS BIGINT;
SET @DA_SHIFT_ID = (SELECT [ID] FROM Shift where SiteId = 3 and [Name] = 'D')

DECLARE @SITE_ID AS BIGINT;

SET @RECURRING_DAILY_ID = 3;

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

   SELECT @SITE_ID = [SiteId] FROM FunctionalLocation WHERE Id = @FLOC_ID;
	
   --
   -- Common repeating log
   --   
   insert into Schedule (
   	LastModifiedDateTime,
   	ScheduleTypeId,
   	StartDateTime,
   	EndDateTime,
   	FromTime,
   	ToTime,
   	DailyFrequency,
   	Deleted,
   	SiteId)
   values (
   	GetDate(),			-- LastModifiedDateTime
   	@RECURRING_DAILY_ID,		-- ScheduleTypeId
   	'2010-08-01 00:00:00.000',	-- StartDateTime
   	NULL,				-- EndDateTime
   	'9:00',			-- FromTime
   	'18:00',			-- ToTime
   	1,				-- DailyFrequency
   	0,		 		-- Deleted
   	@SITE_ID					--SiteId
   );
   
   select @SCHEDULE_ID = @@IDENTITY;

   insert into LogDefinition ([ScheduleId],
   	[CreatedDateTime],
   	[EHSFollowup],
   	[InspectionFollowUp],
   	[ProcessControlFollowUp],
   	[OperationsFollowUp],
   	[SupervisionFollowUp],
   	[OtherFollowUp],
   	[CreatedBy],
	[CreatedByRoleId],
   	[LastModifiedUserId],
   	[LastModifiedDateTime],
   	[Deleted],
	LogType,
	CreateALogForEachFunctionalLocation,
	RtfComments,
	PlainTextComments,
	IsOperatingEngineerLog,
	Active)	
    values(
	@SCHEDULE_ID,			-- ScheduleId
   	'2010-08-01 00:00:00.000',	-- LogDateTime
   	0,				-- EHSFollowup
   	0,				-- InspectionFollowUp
   	0,				-- ProcessControlFollowUp
   	0,				-- OperationsFollowUp
   	0,				-- SupervisionFollowUp
   	0,				-- OtherFollowUp

   	1,				-- CreatedBy
	53,				-- CreatedByRoleId
   	1,				-- LastModifiedUserId
   	GetDate(),			-- LastModifiedDateTime
   	0,				-- Deleted
	1,
	1,
	'Equipment offline for the next 3 days.',
	'Equipment offline for the next 3 days.',
	0,
	1
    );
	
	insert into LogDefinitionFunctionalLocation (LogDefinitionId, FunctionalLocationId)
	values (IDENT_CURRENT('LogDefinition'), @FLOC_ID);
	
	-- "Old" log
	
	insert into Log
	(
		[LogDefinitionId],
		[RootLogId],
		[ReplyToLogId],
		[HasChildren],
		[SourceId],
		[LogDateTime],
		[CreatedDateTime],
		[EHSFollowup],
		[InspectionFollowUp],
		[ProcessControlFollowUp],
		[OperationsFollowUp],
		[SupervisionFollowUp],
		[OtherFollowUp],
		[UserId],
		[CreationUserShiftPatternId],
		[LastModifiedUserId],
		[LastModifiedDateTime],
		[Deleted],
		[CreatedByRoleId],
		[LogType],
		RecommendForShiftSummary,
		RtfComments,
		PlainTextComments,
		IsOperatingEngineerLog
	)
	values
	(
		NULL,
		NULL,
		NULL,
		0,
		0,
		@SOME_DAYS_AGO,
		@SOME_DAYS_AGO,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		@DA_SHIFT_ID,
		1,
		@SOME_DAYS_AGO,
		0,
		53,
		1,
		0,
		'Equipment offline for the next 3 days.',
		'Equipment offline for the next 3 days.',
		0
	);
	
	insert into LogFunctionalLocation (LogId, FunctionalLocationId)
	values (IDENT_CURRENT('Log'), @FLOC_ID);
	
END;
   FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;
END;

CLOSE FLOC_ID_CURSOR;
DEALLOCATE FLOC_ID_CURSOR;

