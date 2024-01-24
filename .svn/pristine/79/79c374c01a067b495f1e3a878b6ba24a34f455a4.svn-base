if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertSchedule]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertSchedule]
GO

CREATE Procedure [dbo].[InsertSchedule]
	(
	@Id bigint Output,
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
    @SiteId bigint,
    @EveryShift bit = NULL
	)
AS

INSERT INTO Schedule
    (
    LastModifiedDateTime, 
    LastInvokedDateTime,
    ScheduleTypeId,
    StartDateTime,
    EndDateTime,
    FromTime,
    ToTime,
    DailyFrequency,
    WeeklyFrequency,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
    DayOfMonth,
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
    SiteId,
    EveryShift
    )
VALUES     
    (
    @LastModifiedDateTime, 
    @LastInvokedDateTime,
    @ScheduleTypeId,
    @StartDateTime,
    @EndDateTime,
    @FromTime,
    @ToTime,
    @DailyFrequency,
    @WeeklyFrequency,
    @Monday,
    @Tuesday,
    @Wednesday,
    @Thursday,
    @Friday,
    @Saturday,
    @Sunday,
    @DayOfMonth,
    @WeekOfMonth,
    @DayOfWeek,
    @January,
    @February,
    @March,
    @April,
    @May,
    @June,
    @July,
    @August,
    @September,
    @October,
    @November,
    @December,
    @SiteId,
    @EveryShift
    )
    
SET @Id = SCOPE_IDENTITY() 
GO
GRANT EXEC ON [InsertSchedule] TO PUBLIC

GO