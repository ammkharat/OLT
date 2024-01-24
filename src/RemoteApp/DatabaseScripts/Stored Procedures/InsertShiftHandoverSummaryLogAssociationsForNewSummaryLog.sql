IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverSummaryLogAssociationsForNewSummaryLog')
	BEGIN
		DROP PROCEDURE [dbo].InsertShiftHandoverSummaryLogAssociationsForNewSummaryLog
	END
GO

CREATE Procedure [dbo].InsertShiftHandoverSummaryLogAssociationsForNewSummaryLog
	(
		@SummaryLogId BIGINT,
		@StartOfDateRange DateTime,
        @EndOfDateRange DateTime,   	   
		@CsvFLOCIds varchar(max),
		@ShiftId bigint,
		@WorkAssignmentId bigint
	)
AS

INSERT INTO ShiftHandoverQuestionnaireSummaryLog (ShiftHandoverQuestionnaireid, SummaryLogId)
SELECT DISTINCT sh.Id, @SummaryLogId
  FROM 
  ShiftHandoverQuestionnaire sh
  INNER JOIN dbo.ShiftHandoverQuestionnaireFunctionalLocation shfl ON shfl.ShiftHandoverQuestionnaireId = sh.Id
WHERE
  sh.ShiftId = @ShiftId AND
  sh.WorkAssignmentId = @WorkAssignmentId AND
  sh.CreatedDateTime <= @EndOfDateRange AND
  sh.CreatedDateTime >= @StartOfDateRange AND
	( 
		EXISTS
		(
		-- Floc of Shift Handover matches one of the passed in flocs
		select * From IDSplitter(@CsvFLOCIds) ids
		WHERE shfl.FunctionalLocationId = ids.Id
		)
		OR EXISTS
		(
		  -- Floc of Shift Handover is a parent of one of Summary Log flocs
		  select a.Id from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		  WHERE shfl.FunctionalLocationId = a.AncestorId
		)
	)
	AND NOT EXISTS (SELECT * From ShiftHandoverQuestionnaireSummaryLog qsl where qsl.ShiftHandoverQuestionnaireId = sh.Id and qsl.SummaryLogId = @SummaryLogId)
OPTION (OPTIMIZE FOR UNKNOWN) 	
GO

GRANT EXEC ON InsertShiftHandoverSummaryLogAssociationsForNewSummaryLog TO PUBLIC
GO