-- ***** Update column [DayOfWeek] data to use an integer representation of a weekday instead of the actual Day names in Schedule table *****
-- 1) Add TempDayOfWeek column to Schedule table
ALTER TABLE [dbo].[Schedule]
ADD TempDayOfWeek int NULL
GO
-- 2) Map all values from DayOfWeek to TempDayOfWeek where Sunday = 7, Monday = 1,... Saturday=6 etc
UPDATE Schedule SET TempDayOfWeek = 1 WHERE DayOfWeek = 'Monday';
UPDATE Schedule SET TempDayOfWeek = 2 WHERE DayOfWeek = 'Tuesday';
UPDATE Schedule SET TempDayOfWeek = 3 WHERE DayOfWeek = 'Wednesday';
UPDATE Schedule SET TempDayOfWeek = 4 WHERE DayOfWeek = 'Thursday';
UPDATE Schedule SET TempDayOfWeek = 5 WHERE DayOfWeek = 'Friday';
UPDATE Schedule SET TempDayOfWeek = 6 WHERE DayOfWeek = 'Saturday';
UPDATE Schedule SET TempDayOfWeek = 7 WHERE DayOfWeek = 'Sunday';
GO
-- 3) Drop DayOfWeek column
ALTER TABLE Schedule
DROP COLUMN DayOfWeek
GO
-- 4) Rename TempDayOfWeek to DayOfWeek
sp_RENAME 'Schedule.[TempDayOfWeek]' , 'DayOfWeek', 'COLUMN'
GO
GO
