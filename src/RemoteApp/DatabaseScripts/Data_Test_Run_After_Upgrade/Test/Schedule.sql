SET IDENTITY_INSERT Schedule ON


--
-- Single Schedules
-- 

-- ID = 1
-- Single Schedule on October 17 From 8AM To 12PM
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    1,
    1,
    '2005-10-17 8:00',
    '2005-10-17 19:00',
    getdate(),
    1
);

--
-- Continuous Schedules
-- 

-- ID = 2
-- Continuous Schedule From October 17 to October 27, 2005
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    2,              -- Id
    2,
    '2005-10-17',
    '2005-10-27',
    getdate(),
    1
);

-- ID = 3
-- Continuous Schedule With No End Date From October 17
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    3,              -- Id
    2,
    '2005-10-17',
    null,
    getdate(),
    1
);

--
-- Recurring Daily Schedules
-- 

-- ID = 4
-- Recurring Daily Schedule For Every 2 Days From 10:12AM To 7:11PM Between Jan 10 And Oct 21, 2000
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    4,              -- Id
    3,
    '2000-01-10',
    '2000-10-21',
    2,
    '1971-08-01 10:12',
    '1971-08-01 19:11',
    getdate(),
    1
);

--
-- Recurring Weekly Schedules
-- 

-- ID = 5
-- Recurring Weekly Schedule For Every Monday And Friday From 8AM To 2PM Between Jan 1 And Oct 10, 2000
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    WeeklyFrequency,
    Monday,
    Friday,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    5,              -- Id
    4,
    '2000-01-01',
    '2000-10-10',
    '1971-08-01 08:00',
    '1971-08-01 14:00',
    1,
    1,
    1,
    getdate(),
    1
);

--
-- Recurring Monthly Schedules
-- 

-- ID = 6
-- Monthly Schedule From 8AM To 12PM For The 15th Day Of January And February Between January 1 And December 31, 2005
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    DayOfMonth,
    January,
    February,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    6,              -- Id
    5,
    '2005-01-01',
    '2005-12-31',
    '1971-08-01 08:00',
    '1971-08-01 18:00',
    15,
    1,
    1,
    getdate(),
    1
);

-- ID = 7
-- Monthly Schedule From 8AM To 12PM For The Last Day Of January And February Between January 1 And December 31, 2005
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    DayOfMonth,
    January,
    February,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    7,              -- Id
    5,
    '2005-01-01',
    '2005-12-31',
    '1971-08-01 08:00',
    '1971-08-01 17:00',
    99,
    1,
    1,
    getdate(),
    1
);

-- ID = 8
-- Monthly Schedule From 9AM To 4PM For The Second Wednesday Of March And May Between January 1 And December 31, 2005
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    WeekOfMonth,
    DayOfWeek,
    March,
    May,
    LastModifiedDateTime,
    SiteId
) 
VALUES 
(
    8,              -- Id
    6,
    '2005-01-01',
    '2005-12-31',
    '1971-08-01 09:00',
    '1971-08-01 16:00',
    2,
    3,
    1,
    1,
    getdate(),
    1
);

-- ID = 9
-- Monthly Schedule From 8AM To 5PM For The Last Friday Of All Months Between January 1 And December 31, 2005
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    WeekOfMonth,
    DayOfWeek,
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December,
    LastModifiedDateTime,
    SiteId
) 
VALUES 
(

    9,              -- Id
    6,
    '2005-01-01',
    '2005-12-31',
    '1971-08-01 08:00',
    '1971-08-01 16:00',
    99,
    5,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    getdate(),
    1
);

-- Recurring Hourly Schedules
-- 

-- ID = 10
-- Recurring Hourly Schedule For Every 6 Hours From 12:00AM To 12:00AM Between Jan 1 And Dec 31, 2007
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
) 
VALUES 
(
    10,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- Recurring Minute Schedules
-- 

-- ID = 11
-- Recurring Minute Schedule For Every 15 Minutes From 12:00AM To 12:00AM Between April 1, 2005 And April 1, 2007
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
) 
VALUES
(
    11,              -- Id
    8,
    '2005-04-01',
    '2007-04-01',
    15,
    '1971-08-01 12:00',
    '1971-08-01 23:59',
    getdate(),
    1
);

-- ID = 12
-- Recurring Daily Schedule For Every 2 Days From 10:12AM To 7:11PM Between Jan 10 And Oct 21, 2000
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
) 
VALUES
(
    12,              -- Id
    3,
    '2000-01-10',
    '2000-10-21',
    2,
    '1971-08-01 10:12',
    '1971-08-01 19:11',
    getdate(),
    1
);

--
-- Recurring Weekly Schedules
-- 

-- ID = 13
-- Recurring Weekly Schedule For Every Monday And Friday From 8AM To 2PM Between Jan 1 And Oct 10, 2000
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    WeeklyFrequency,
    Monday,
    Friday,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    13,              -- Id
    4,
    '2000-01-01',
    '2000-10-10',
    '1971-08-01 08:00',
    '1971-08-01 14:00',
    1,
    1,
    1,
    getdate(),
    1
);

--
-- Recurring Monthly Schedules
-- 

-- ID = 14
-- Monthly Schedule From 8AM To 12PM For The 15th Day Of January And February Between January 1 And December 31, 2005
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    DayOfMonth,
    January,
    February,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    14,              -- Id
    5,
    '2005-01-01',
    '2005-12-31',
    '1971-08-01 08:00',
    '1971-08-01 18:00',
    15,
    1,
    1,
    getdate(),
    1
);

-- ID = 15
-- Recurring Hourly Schedule For Every 6 Hours From 12:00AM To 12:00AM Between Jan 1 And Dec 31, 2007
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    15,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:23',
    getdate(),
    1
);

-- Recurring Minute Schedules
-- 

-- ID = 16
-- Recurring Minute Schedule For Every 1 Minutes From 8:00AM To 5:00PM Between April 1, 2005 And April 1, 2007
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
) 
VALUES 
(
    16,              -- Id
    8,
    '2005-04-01',
    '2007-04-01',
    1,
    '1971-08-01 08:00',
    '1971-08-01 17:00',
    getdate(),
    1
);

-- ID = 17
-- Another Recurring Hourly Schedule For Every 6 Hours From 12:00AM To 12:00AM Between Jan 1 And Dec 31, 2007
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    17,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 18
-- Just here for other target definition test data  (id's 18 and 19)
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    18,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 19
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    19,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 20
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    20,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 21
-- Just for a TargetDefinition, 
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    21,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 22
-- Just for a TargetDefinition, 
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    22,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 23
-- Just for a TargetDefinition with comments 
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    23,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 24
-- Just for a TargetDefinition with with two associated targets
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    24,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 25
-- Just for a TargetDefinition with with a parent
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    25,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 26
-- Just for a TargetDefinition with with a parent
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    26,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 27
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    27,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 28
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    28,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 29
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    29,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 30
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    30,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);


-- ID = 31
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    31,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 32
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    32,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 33
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    33,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 34
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    34,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 35
-- Just for a TargetDefinition
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    35,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

--
-- Single Schedules
-- 

-- ID = 36
-- Single Schedule on October 17 From 8AM To 12PM
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    36,
    1,
    '2005-10-17 8:00',
    '2005-10-17 19:00',
    getdate(),
    1
);


--
-- Single Schedules
-- 

-- ID = 37
-- Single Schedule on October 17 From 8AM To 12PM
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    37,
    1,
    '2005-10-17 8:00',
    '2005-10-17 19:00',
    getdate(),
    1
);


--
-- Single Schedules
-- 

-- ID = 38
-- Single Schedule on October 17 From 8AM To 12PM
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    38,
    1,
    '2005-10-17 8:00',
    '2005-10-17 19:00',
    getdate(),
    1
);

--
-- Single Schedules
-- 

-- ID = 39
-- Recurring Weekly Schedule For Every Monday And Friday From 8AM To 2PM Between Jan 1 And Oct 10, 2000
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    WeeklyFrequency,
    Monday,
    Friday,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    39,              -- Id
    4,
    '2000-01-01',
    '2000-10-10',
    '1971-08-01 08:00',
    '1971-08-01 14:00',
    1,
    1,
    1,
    getdate(),
    1
);

-- ID = 40
-- Monthly Schedule From 8AM To 12PM For The 15th Day Of January And February Between January 1 And December 31, 2005
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    DayOfMonth,
    January,
    February,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    40,              -- Id
    5,
    '2005-01-01',
    '2005-12-31',
    '1971-08-01 08:00',
    '1971-08-01 18:00',
    15,
    1,
    1,
    getdate(),
    1
);

-- ID = 41
-- Monthly Schedule From 8AM To 12PM For The Last Day Of January And February Between January 1 And December 31, 2005
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    DayOfMonth,
    January,
    February,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    41,              -- Id
    5,
    '2005-01-01',
    '2005-12-31',
    '1971-08-01 08:00',
    '1971-08-01 17:00',
    99,
    1,
    1,
    getdate(),
    1
);

-- ID = 42
-- Monthly Schedule From 9AM To 4PM For The Second Wednesday Of March And May Between January 1 And December 31, 2005
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    WeekOfMonth,
    DayOfWeek,
    March,
    May,
    LastModifiedDateTime,
    SiteId
) 
VALUES 
(
    42,              -- Id
    6,
    '2005-01-01',
    '2005-12-31',
    '1971-08-01 09:00',
    '1971-08-01 16:00',
    2,
    3,
    1,
    1,
    getdate(),
    1
);

-- ID = 43
-- Monthly Schedule From 8AM To 5PM For The Last Friday Of All Months Between January 1 And December 31, 2005
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    WeekOfMonth,
    DayOfWeek,
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December,
    LastModifiedDateTime,
    SiteId
) 
VALUES 
(

    43,              -- Id
    6,
    '2005-01-01',
    '2005-12-31',
    '1971-08-01 08:00',
    '1971-08-01 16:00',
    99,
    5,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    getdate(),
    1
);

-- Recurring Hourly Schedules
-- 

-- ID = 44
-- Recurring Hourly Schedule For Every 6 Hours From 12:00AM To 12:00AM Between Jan 1 And Dec 31, 2007
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
) 
VALUES 
(
    44,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- Recurring Minute Schedules
-- 

-- ID = 45
-- Recurring Minute Schedule For Every 15 Minutes From 12:00AM To 12:00AM Between April 1, 2005 And April 1, 2007
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
) 
VALUES
(
    45,              -- Id
    8,
    '2005-04-01',
    '2007-04-01',
    15,
    '1971-08-01 12:00',
    '1971-08-01 23:59',
    getdate(),
    1
);

-- ID = 46
-- Another Recurring Hourly Schedule For Every 6 Hours From 12:00AM To 12:00AM Between Jan 1 And Dec 31, 2007
INSERT INTO Schedule
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
)
VALUES
(
    46,              -- Id
    7,
    '2007-01-01',
    '2007-12-31',
    6,
    '1971-08-01 12:00',
    '1971-08-01 20:33',
    getdate(),
    1
);

-- ID = 47
-- Recurring Daily Schedule For Every 2 Days From 10:12AM To 7:11PM Between Jan 10 And Oct 21, 2000
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
) 
VALUES
(
    47,              -- Id
    3,
    '2000-01-10',
    '2000-10-21',
    2,
    '1971-08-01 10:12',
    '1971-08-01 19:11',
    getdate(),
    1
);

-- ID = 48
-- Recurring Daily Schedule For Every 2 Days From 10:12AM To 7:11PM Between Jan 10 And Oct 21, 2000
INSERT INTO Schedule 
(
    Id,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    DailyFrequency,
    FromTime,
    ToTime,
    LastModifiedDateTime,
    SiteId
) 
VALUES
(
    48,              -- Id
    3,
    '2000-01-10',
    '2000-10-21',
    2,
    '1971-08-01 10:12',
    '1971-08-01 19:11',
    getdate(),
    1
);

SET IDENTITY_INSERT Schedule OFF