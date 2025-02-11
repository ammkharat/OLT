if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCokerCardCycleStepEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCokerCardCycleStepEntry]
GO

CREATE Procedure [dbo].[InsertCokerCardCycleStepEntry]
    (
    @Id bigint Output,
	@CokerCardId bigint,
	@CokerCardConfigurationDrumId bigint,
    @CokerCardConfigurationCycleStepId bigint,    
    @StartTime datetime,  
	@StartEntryShiftId bigint,
	@StartEntryShiftStartDate datetime,  
    @EndTime datetime = NULL,  
	@EndEntryShiftId bigint = NULL,
	@EndEntryShiftStartDate datetime = NULL
    )
AS

INSERT INTO CokerCardCycleStepEntry
(
	CokerCardId,
	CokerCardConfigurationDrumId,
	CokerCardConfigurationCycleStepId,
	StartTime,
	StartEntryShiftId,
	StartEntryShiftStartDate,
	EndTime,
	EndEntryShiftId,
	EndEntryShiftStartDate
)
VALUES
(	
	@CokerCardId,
	@CokerCardConfigurationDrumId,
	@CokerCardConfigurationCycleStepId,
	@StartTime,
	@StartEntryShiftId,
	@StartEntryShiftStartDate,
	@EndTime,
	@EndEntryShiftId,
	@EndEntryShiftStartDate
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertCokerCardCycleStepEntry] TO PUBLIC
GO
