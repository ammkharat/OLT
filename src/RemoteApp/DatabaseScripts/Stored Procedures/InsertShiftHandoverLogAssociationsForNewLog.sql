IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverLogAssociationsForNewLog')
	BEGIN
		DROP PROCEDURE [dbo].InsertShiftHandoverLogAssociationsForNewLog
	END
GO

CREATE Procedure [dbo].InsertShiftHandoverLogAssociationsForNewLog
	(
		@LogId BIGINT,
		@StartOfDateRange DateTime,
        @EndOfDateRange DateTime,   	   
		@CsvFLOCIds varchar(max),
		@ShiftId bigint,
		@WorkAssignmentId bigint
	)
AS

INSERT INTO ShiftHandoverQuestionnaireLog (ShiftHandoverQuestionnaireid, LogId)
SELECT DISTINCT sh.Id, @LogId
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
		-- Floc of Shift Handover is the same as one of the Log flocs
		select * From IDSplitter(@CsvFLOCIds) ids
		WHERE shfl.FunctionalLocationId = ids.Id
		)
		OR EXISTS
		(
		  -- Floc of Shift Handover is a parent of one of Log flocs
		  select a.Id from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		  WHERE shfl.FunctionalLocationId = a.AncestorId
		)
	)
	AND NOT EXISTS (SELECT * From ShiftHandoverQuestionnaireLog ql where ql.ShiftHandoverQuestionnaireId = sh.Id and ql.LogId = @LogId)
OPTION (OPTIMIZE FOR UNKNOWN) 	
GO

GRANT EXEC ON InsertShiftHandoverLogAssociationsForNewLog TO PUBLIC
GO