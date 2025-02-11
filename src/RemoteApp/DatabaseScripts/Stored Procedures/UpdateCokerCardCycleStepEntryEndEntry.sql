if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCokerCardCycleStepEntryEndEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCokerCardCycleStepEntryEndEntry]
GO

CREATE Procedure [dbo].[UpdateCokerCardCycleStepEntryEndEntry]
    (
    @Id bigint,
    @EndTime datetime = NULL,  
	@EndEntryShiftId bigint = NULL,
	@EndEntryShiftStartDate datetime = NULL
    )
AS

UPDATE CokerCardCycleStepEntry
set	EndTime = @EndTime,
	EndEntryShiftId = @EndEntryShiftId,
	EndEntryShiftStartDate = @EndEntryShiftStartDate
where Id = @Id


GRANT EXEC ON [UpdateCokerCardCycleStepEntryEndEntry] TO PUBLIC
GO
