DECLARE @FLOC_ID BIGINT;
DECLARE @SCHEDULE_ID BIGINT;
DECLARE @RECURRING_DAILY_ID BIGINT;
DECLARE @NEXT_ID CHAR(12);

DECLARE @61_DAYS_AGO AS DATETIME;
SET @61_DAYS_AGO = CONVERT(DATETIME, CONVERT(char(10), GetDate() - 61, 110) + ' 10:00:00.000');

DECLARE @SARNIA_DA_SHIFT_ID AS BIGINT;
SET @SARNIA_DA_SHIFT_ID = (SELECT [ID] FROM Shift where SiteId = 1 and [Name] = '12DA')

DECLARE @SITE_ID AS BIGINT;

SET @RECURRING_DAILY_ID = 3;

DECLARE FLOC_ID_CURSOR CURSOR
FOR
  SELECT Id FROM FunctionalLocation
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
   	'2006-03-01 00:00:00.000',	-- StartDateTime
   	NULL,				-- EndDateTime
   	'10:30',			-- FromTime
   	'18:00',			-- ToTime
   	1,				-- DailyFrequency
   	0,				-- Deleted
   	1					--SiteId
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
      values(@SCHEDULE_ID,			-- ScheduleId
   	'2006-03-01 00:00:00.000',	-- LogDateTime
   	0,				-- EHSFollowup
   	0,				-- InspectionFollowUp
   	0,				-- ProcessControlFollowUp
   	0,				-- OperationsFollowUp
   	1,				-- SupervisionFollowUp
   	0,				-- OtherFollowUp
   	1,				-- CreatedBy
	53,				-- CreatedByRoleId
   	1,				-- LastModifiedUserId
   	GetDate(),			-- LastModifiedDateTime
   	0,				-- Deleted
	1,
	1,
	'Bypass Valve is temporarily cracked open ...',
	'Bypass Valve is temporarily cracked open ...',
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
		@61_DAYS_AGO,
		@61_DAYS_AGO,
		0,
		0,
		0,
		1,
		0,
		0,
		1,
		@SARNIA_DA_SHIFT_ID,
		1,
		@61_DAYS_AGO,
		0,
		53,
		1,
		0,
		'Old log',
		'Old log',
		0
	);
	
	insert into LogFunctionalLocation (LogId, FunctionalLocationId)
	values (IDENT_CURRENT('Log'), @FLOC_ID);
		
END;
   FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;
END;

CLOSE FLOC_ID_CURSOR;
DEALLOCATE FLOC_ID_CURSOR;

