IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverSummaryLogAssociationsForNewShiftHandover')
	BEGIN
		DROP PROCEDURE [dbo].InsertShiftHandoverSummaryLogAssociationsForNewShiftHandover
	END
GO

CREATE Procedure [dbo].InsertShiftHandoverSummaryLogAssociationsForNewShiftHandover
	(
		@ShiftHandoverQuestionnaireId BIGINT,
		@StartOfDateRange DateTime,
        @EndOfDateRange DateTime,   	   
		@CsvFLOCIds varchar(max),
		@ShiftId bigint,
		@WorkAssignmentId bigint
	)
AS

INSERT INTO ShiftHandoverQuestionnaireSummaryLog (ShiftHandoverQuestionnaireid, SummaryLogId)
SELECT 
  DISTINCT @ShiftHandoverQuestionnaireId, sl.Id 
FROM
  [SummaryLog] sl
  INNER JOIN SummaryLogFunctionalLocation slfl ON slfl.SummaryLogId = sl.Id
WHERE
	sl.Deleted = 0 AND
	sl.CreatedDateTime <= @EndOfDateRange AND
	sl.CreatedDateTime >= @StartOfDateRange AND    	
	sl.CreationuserShiftPatternId = @ShiftId AND	
	sl.WorkAssignmentId = @WorkAssignmentId AND
	( 
		EXISTS
		(
		-- Floc of Log matches one of the passed in flocs
		select * From IDSplitter(@CsvFLOCIds) ids
		WHERE slfl.FunctionalLocationId = ids.Id
		)
		OR EXISTS
		(
		  -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select a.Id from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		  WHERE slfl.FunctionalLocationId = a.Id
		)
	)
	AND NOT EXISTS (SELECT * From ShiftHandoverQuestionnaireSummaryLog qsl where qsl.ShiftHandoverQuestionnaireId = @ShiftHandoverQuestionnaireid and qsl.SummaryLogId = sl.Id)
OPTION (OPTIMIZE FOR UNKNOWN) 	
GO

GRANT EXEC ON InsertShiftHandoverSummaryLogAssociationsForNewShiftHandover TO PUBLIC
GO