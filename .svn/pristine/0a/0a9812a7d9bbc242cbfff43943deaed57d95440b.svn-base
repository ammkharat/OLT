IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetAlertsByFunctionalLocationsAndUserShift')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetAlertsByFunctionalLocationsAndUserShift
	END
GO

CREATE Procedure [dbo].QueryTargetAlertsByFunctionalLocationsAndUserShift
	(
		@CsvFlocIds VARCHAR(MAX),
		@ShiftStartDateTime datetime,
		@ShiftEndDateTime datetime
	)
AS

select 
	TargetAlert.*
from 
	TargetAlert 
	INNER JOIN FunctionalLocation floc 
		ON TargetAlert.FunctionalLocationId = floc.Id
where 
	TargetAlert.CreatedDateTime BETWEEN @ShiftStartDateTime AND @ShiftEndDateTime 
	AND
	(
		EXISTS
		(
		-- Floc of target alert matches one of the passed in flocs
		SELECT ids.Id
		FROM 
			IDSplitter(@CsvFlocIds) ids
		WHERE 
			ids.Id = floc.Id
		)
		OR
		EXISTS
		(
		-- Floc of  target alert is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		SELECT ids.Id
		FROM 
			IDSplitter(@CsvFlocIds) ids 
			INNER JOIN FunctionalLocationAncestor a ON a.AncestorId = ids.Id
		WHERE 
			a.Id = floc.Id
		  )
	)
OPTION (OPTIMIZE FOR UNKNOWN)  		
GO
 
GRANT EXEC ON QueryTargetAlertsByFunctionalLocationsAndUserShift TO PUBLIC
GO