DECLARE @UnitLevelFloc1 AS varchar(max);
SET @UnitLevelFloc1 = 'SR1';

declare @roleid bigint;

select top 1 @roleId = id from role where siteid = 1

INSERT INTO [Log]
(
	LogDefinitionId, 
	RootLogId, 
	ReplyToLogId, 
	SourceId, 
	LogDateTime, 
	EHSFollowup, 
	InspectionFollowUp, 
	ProcessControlFollowUp, 
	OperationsFollowUp, 
	SupervisionFollowUp, 
	OtherFollowUp, 
	UserId, 
	CreationUserShiftPatternId, 
	LastModifiedUserId, 
	LastModifiedDateTime, 
	Deleted, 
	LogType, 
	RecommendForShiftSummary, 
	WorkAssignmentId, 
	PlainTextComments, 
	CreatedDateTime, 
	CreatedByRoleId, 
	IsOperatingEngineerLog, 
	RtfComments, 
	HasChildren
) 
VALUES 
(
	null, 
	null,
	null, 
	0, 
	getdate(),
	0,
	0,
	0,
	0,
	0,
	0, 
	1, 
	1,
	1,
	getdate(),
	0,
	1,
	0,
	null,
	'dummy log',
	getdate(),
	@roleid,
	0,
	'dummy log',
	0
)

declare @logid bigint;
set @logid = @@IDENTITY;

INSERT INTO [LogHistory]
(
    Id,
    FunctionalLocations,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    LastModifiedUserId,
    LastModifiedDateTime,
	RecommendForShiftSummary,
	IsOperatingEngineerLog,
	PlainTextComments
)
VALUES
(
    @logid,                                                                  -- Id
    @UnitLevelFloc1,                                                    -- FunctionalLocations,
    0,                                                                  -- EHSFollowup,
    0,                                                                  -- ProcessControlFollowUp,
    0,                                                                  -- InspectionFollowUp,
    0,                                                                  -- OperationsFollowUp,
    0,                                                                  -- SupervisionFollowUp,
    1,                                                                  -- OtherFollowUp,
    1,                                                                  -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),                      -- LastModifiedDateTime,
	0,
	0,
	'At the current low rates, the Alky Unit can accept up to 10% ' +   -- PlainTextComments,
    'nC4in our iC4 product. Keep the iC4 going on the onspec well ' +
    'as long ast the nC4 concentration is less than 10%'
)

INSERT INTO [LogHistory]
(
    Id,
    FunctionalLocations,
    EHSFollowup,
    ProcessControlFollowUp,
    InspectionFollowUp,
    OperationsFollowUp,
    SupervisionFollowUp,
    OtherFollowUp,
    LastModifiedUserId,
    LastModifiedDateTime,
	RecommendForShiftSummary,
	IsOperatingEngineerLog,
	PlainTextComments
)
VALUES
(
    @logid,                                                                  -- Id
    @UnitLevelFloc1,                                                    -- FunctionalLocations,
    1,                                                                  -- EHSFollowup,
    1,                                                                  -- ProcessControlFollowUp,
    1,                                                                  -- InspectionFollowUp,
    1,                                                                  -- OperationsFollowUp,
    1,                                                                  -- SupervisionFollowUp,
    1,                                                                  -- OtherFollowUp,
    1,                                                                  -- LastModifiedUserId,
    CONVERT(DATETIME, '2005-11-01 00:00:00', 102),                      -- LastModifiedDateTime,
	0,
	0,
	'At the current low rates, the Alky Unit can accept up to 10% ' +   -- PlainTextComments,
    'nC4in our iC4 product. Keep the iC4 going on the onspec well ' +
    'as long ast the nC4 concentration is less than 10% - changed'
)
