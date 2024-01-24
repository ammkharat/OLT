 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertCokerCardDrumEntryHistory')
	BEGIN
		DROP  Procedure  InsertCokerCardDrumEntryHistory
	END

GO

CREATE Procedure [dbo].[InsertCokerCardDrumEntryHistory]
	(
	@Id bigint Output,
	@CokerCardHistoryId bigint, 
	@DrumConfigurationId bigint, 
	@DrumName VARCHAR(40),
	@CokerCardConfigurationLastCycleStep varchar(20) = null,
	@HoursIntoLastCycle decimal(4,2) = null, 
	@Comments VARCHAR(200) = null
	)
AS

INSERT INTO 
	[CokerCardDrumEntryHistory]
	(
	[CokerCardHistoryId],
	[DrumConfigurationId], 	
	[DrumName],
	CokerCardConfigurationLastCycleStep,
	HoursIntoLastCycle,
	[Comments]
	)
VALUES
	(
	@CokerCardHistoryId,
	@DrumConfigurationId,
	@DrumName, 
	@CokerCardConfigurationLastCycleStep,
	@HoursIntoLastCycle,
	@Comments
	)
	
SET @Id= SCOPE_IDENTITY() 
GO

