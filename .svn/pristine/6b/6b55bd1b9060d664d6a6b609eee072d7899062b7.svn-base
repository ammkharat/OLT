-- ZZZ scripts reference this function to move the date in 
-- the zzz_ data files from their current date to the difference between now and the date below.
-- for example, a log with the date Jan 16, 2012, a @backup_date of '2012-jan-22', 
-- running this script on Jan 27, 2012 will adjust the log date by 5 days - the delta between now and @backup_date.

CREATE Function dbo.[DeltaDay] ()  
Returns int AS

BEGIN
	declare @backup_date as datetime
	set @backup_date = '2014-Aug-17'

	return datediff(day, @backup_date, getdate())
END  
go

-- reseed the Schedules
UPDATE Schedule
SET 
	StartDateTime = StartDateTime + dbo.DeltaDay()
	
UPDATE Schedule
SET
	EndDateTime = EndDateTime + dbo.DeltaDay()
WHERE
	EndDateTime IS NOT NULL

UPDATE ActionItem
SET 
	StartDateTime = StartDateTime + dbo.DeltaDay()

UPDATE ActionItem
SET 
	EndDateTime = EndDateTime + dbo.DeltaDay()
WHERE 
	EndDateTime IS NOT NULL AND EndDateTime < '9999-01-01' 

UPDATE ActionItem
SET 
	ShiftAdjustedEndDateTime = ShiftAdjustedEndDateTime + dbo.DeltaDay()
WHERE 
	ShiftAdjustedEndDateTime IS NOT NULL AND ShiftAdjustedEndDateTime < '9999-01-01'

UPDATE LogDefinition
SET 
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay(),
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()
	
UPDATE [Log]
SET
	LogDateTime = LogDateTime + dbo.DeltaDay(),
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay()
	
UPDATE SapNotification
SET
	CreationDateTime = CreationDateTime + dbo.DeltaDay()

UPDATE [SummaryLog]
SET
	LogDateTime = LogDateTime + dbo.DeltaDay(),
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay()
	
UPDATE ShiftHandoverQuestionnaire
SET
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay(),
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()
	
UPDATE WorkPermit
SET 
	StartDateTime = StartDateTime + dbo.DeltaDay()
WHERE
	StartDateTime IS NOT NULL
	
UPDATE WorkPermit
SET 
	EndDateTime = EndDateTime + dbo.DeltaDay()
WHERE
	EndDateTime IS NOT NULL	

UPDATE PermitRequestMontreal
SET
	StartDate = StartDate + dbo.DeltaDay(),
	EndDate = EndDate + dbo.DeltaDay(),
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay(),
	LastSubmittedDateTime = LastSubmittedDateTime + dbo.DeltaDay()
UPDATE PermitRequestMontreal
SET
	LastImportedDateTime = LastImportedDateTime + dbo.DeltaDay()
WHERE
	LastImportedDateTime IS NOT NULL
	
UPDATE WorkPermitMontreal
SET 
	StartDateTime = StartDateTime + dbo.DeltaDay(),
	EndDateTime = EndDateTime + dbo.DeltaDay(),
	CreatedDateTime =  CreatedDateTime+ dbo.DeltaDay(),
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()
WHERE
	LastModifiedDateTime IS NOT NULL	

UPDATE CokerCard
SET
	ShiftStartDate = ShiftStartDate + dbo.DeltaDay(),
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay(),
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()
	
UPDATE CokerCardCycleStepEntry
SET
	StartEntryShiftStartDate = StartEntryShiftStartDate + dbo.DeltaDay(),
	EndEntryShiftStartDate = EndEntryShiftStartDate + dbo.DeltaDay()
	
UPDATE LabAlertDefinition
SET
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay(),
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()
	
UPDATE LabAlert
SET
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay(),
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()	

UPDATE LabAlertResponse
SET
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay()
	
UPDATE RestrictionDefinition
SET
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()	

UPDATE RestrictionDefinition
SET
	LastInvokedDateTime = LastInvokedDateTime + dbo.DeltaDay()	
	
UPDATE DeviationAlert
SET
	StartDateTime = StartDateTime + dbo.DeltaDay(),
	EndDateTime = EndDateTime + dbo.DeltaDay(),	
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay(),
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()

UPDATE DeviationAlertResponse
SET
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay(),
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()

UPDATE DeviationAlertResponseReasonCodeAssignment	
SET
	CreatedDateTime = CreatedDateTime + dbo.DeltaDay(),
	LastModifiedDateTime = LastModifiedDateTime + dbo.DeltaDay()
GO

drop function [DeltaDay]
go
