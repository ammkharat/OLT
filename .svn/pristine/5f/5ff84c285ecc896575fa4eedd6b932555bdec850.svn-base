IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSchedule')
	BEGIN
		DROP  Procedure  UpdateSchedule
	END

GO

CREATE Procedure [dbo].UpdateSchedule
	(
	@Id bigint,
	@LastModifiedDateTime datetime, 
	@LastInvokedDateTime datetime,
	@ScheduleTypeId bigint,
	@StartDateTime datetime,
	@EndDateTime datetime = NULL,
    @FromTime datetime = NULL,
    @ToTime datetime = NULL,
    @DailyFrequency int = NULL,
    @WeeklyFrequency int = NULL,
    @Monday bit = NULL,
    @Tuesday bit = NULL,
    @Wednesday bit = NULL,
    @Thursday bit = NULL,
    @Friday bit = NULL,
    @Saturday bit = NULL,
    @Sunday bit = NULL,
    @DayOfMonth int = NULL,
    @WeekOfMonth int = NULL,
    @DayOfWeek int = NULL,
    @January bit = NULL,
    @February bit = NULL,
    @March bit = NULL,
    @April bit = NULL,
    @May bit = NULL,
    @June bit = NULL,
    @July bit = NULL,
    @August bit = NULL,
    @September bit = NULL,
    @October bit = NULL,
    @November bit = NULL,
    @December bit = NULL,
    @EveryShift bit = Null
	)
AS
UPDATE Schedule
SET LastModifiedDateTime = @LastModifiedDateTime,
    LastInvokedDateTime = @LastInvokedDateTime,
    ScheduleTypeId = @ScheduleTypeId,
    StartDateTime = @StartDateTime,
    EndDateTime = @EndDateTime,
    FromTime = @FromTime,
    ToTime = @ToTime,
    DailyFrequency = @DailyFrequency,
    WeeklyFrequency = @WeeklyFrequency,
    Monday = @Monday,
    Tuesday = @Tuesday,
    Wednesday = @Wednesday,
    Thursday = @Thursday,
    Friday = @Friday,
    Saturday = @Saturday,
    Sunday = @Sunday,
    DayOfMonth = @DayOfMonth,
    WeekOfMonth = @WeekOfMonth,
    DayOfWeek = @DayOfWeek,
    January = @January,
    February = @February,
    March = @March,
    April = @April,
    May = @May,
    June = @June,
    July = @July,
    August = @August, 
    September = @September, 
    October = @October,
    November = @November,
    December = @December,
    EveryShift = @EveryShift
WHERE Id = @Id
GO

GRANT EXEC ON UpdateSchedule TO PUBLIC

GO