IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverLogAssociationsForNewShiftHandover')
	BEGIN
		DROP PROCEDURE [dbo].InsertShiftHandoverLogAssociationsForNewShiftHandover
	END
GO

CREATE Procedure [dbo].InsertShiftHandoverLogAssociationsForNewShiftHandover
	(
		@ShiftHandoverQuestionnaireId BIGINT,
		@StartOfDateRange DateTime,
        @EndOfDateRange DateTime,   	   
		@CsvFLOCIds varchar(max),
		@ShiftId bigint,
		@WorkAssignmentId bigint
	)
AS

INSERT INTO ShiftHandoverQuestionnaireLog (ShiftHandoverQuestionnaireid, LogId)
SELECT 
  DISTINCT @ShiftHandoverQuestionnaireId, l.Id 
FROM
  [Log] l
  INNER JOIN LogFunctionalLocation lfl ON lfl.LogId = l.Id
WHERE
	l.Deleted = 0 AND
	l.LogType = 1 AND
	l.CreatedDateTime <= @EndOfDateRange AND
	l.CreatedDateTime >= @StartOfDateRange AND    	
	l.CreationuserShiftPatternId = @ShiftId AND	
	l.WorkAssignmentId = @WorkAssignmentId AND
	( 
		EXISTS
		(
		-- Floc of Log matches one of the passed in flocs
		select * From IDSplitter(@CsvFLOCIds) ids
		WHERE lfl.FunctionalLocationId = ids.Id
		)
		OR EXISTS
		(
		  -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select a.Id from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		  WHERE lfl.FunctionalLocationId = a.Id
		)
	)
	AND NOT EXISTS (SELECT * From ShiftHandoverQuestionnaireLog ql where ql.ShiftHandoverQuestionnaireId = @ShiftHandoverQuestionnaireid and ql.LogId = l.Id)
OPTION (OPTIMIZE FOR UNKNOWN) 	
GO

GRANT EXEC ON InsertShiftHandoverLogAssociationsForNewShiftHandover TO PUBLIC
GO