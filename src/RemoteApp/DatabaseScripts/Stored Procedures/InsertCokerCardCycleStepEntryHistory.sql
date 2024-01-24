 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertCokerCardCycleStepEntryHistory')
	BEGIN
		DROP  Procedure  InsertCokerCardCycleStepEntryHistory
	END

GO

CREATE Procedure [dbo].[InsertCokerCardCycleStepEntryHistory]
	(
	@Id bigint Output,
	@CokerCardDrumEntryHistoryId bigint, 
	@CycleStepConfigurationId bigint, 
	@CycleStepName VARCHAR(40),
	@StartTime datetime  = null,
	@EndTime datetime  = null
	)
AS

INSERT INTO 
	[CokerCardCycleStepEntryHistory]
	(
	[CokerCardDrumEntryHistoryId],
	[CycleStepConfigurationId], 	
	[CycleStepName],
	[StartTime],
	[EndTime]
	)
VALUES
	(
	@CokerCardDrumEntryHistoryId,
	@CycleStepConfigurationId,
	@CycleStepName, 
	@StartTime,
	@EndTime
	)
	
SET @Id= SCOPE_IDENTITY() 
GO

