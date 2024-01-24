
declare @ScheduleId bigint;

insert into Schedule (LastModifiedDateTime, ScheduleTypeId, StartDateTime, FromTime, ToTime, DailyFrequency, Deleted, SiteId)
values ('2013-12-23 14:12', 3, '2013-12-23 00:00:00.000', '1900-01-01 18:00:00.000', '1900-01-01 18:00:00.000', 1, 0, 8);

SET @ScheduleId = SCOPE_IDENTITY();

insert into SapAutoImportConfiguration (SiteId, ScheduleId) values (8, @ScheduleId);






GO

