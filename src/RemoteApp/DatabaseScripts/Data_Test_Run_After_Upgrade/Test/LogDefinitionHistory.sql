DECLARE @Floc AS varchar(max);
set @Floc = 'SR1'

INSERT LogDefinitionHistory
(
    [Id],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [FunctionalLocations],
    [InspectionFollowUp],
    [ProcessControlFollowUp],
    [OperationsFollowUp],
    [SupervisionFollowUp],
    [EnvironmentalHealthSafetyFollowUp],
    [OtherFollowUp],
    [Deleted],
    [Schedule],
    [DocumentLinks],
	[PlainTextComments],
	[Active]
)
VALUES
(
    1,                                                                              -- [Id]
    1,                                                                              -- [LastModifiedUserId]
    CONVERT(DATETIME, '2006-08-25 00:00:00', 102),                                  -- [LastModifiedDateTime]
    @Floc,                                                                            -- [FunctionalLocationId]
    0,                                                                              -- [InspectionFollowUp]
    0,                                                                              -- [ProcessControlFollowUp]
    0,                                                                              -- [OperationsFollowUp]
    0,                                                                              -- [SupervisionFollowUp]
    0,                                                                              -- [EnvironmentalHealthSafetyFollowUp]
    0,                                                                              -- [OtherFollowUp]
    0,                                                                              -- [Deleted]
    'Every 1 day(s)  from 08/25/2006 to 08/25/2006 between 9:00 PM and 9:00 PM',    -- [Schedule]
    'Link 1 (Link 1 Link)' ,                                                        -- [DocumentLinks],
	'Target Definition With History',												-- [PlainTextComments]
	1
)

GO