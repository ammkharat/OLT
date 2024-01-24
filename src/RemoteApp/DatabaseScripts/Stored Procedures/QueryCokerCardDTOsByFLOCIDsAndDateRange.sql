IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardDTOsByFLOCIDsAndDateRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryCokerCardDTOsByFLOCIDsAndDateRange
    END
GO

CREATE Procedure [dbo].QueryCokerCardDTOsByFLOCIDsAndDateRange
    (
        @IDs varchar(MAX),
		@FromDate DateTime,
		@ToDate DateTime
    )
AS

SELECT
    CokerCard.Id,
	CokerCard.ShiftStartDate,
	CokerCard.CreatedDateTime,
	CokerCard.CreatedByUserId,
	CokerCardConfiguration.Name as CokerCardConfigurationName,
    FunctionalLocation.FullHierarchy as FunctionalLocationName,
	WorkAssignment.Name as WorkAssignmentName,
    CreatedByUser.LastName AS CreatedByLastName,
    CreatedByUser.FirstName AS CreatedByFirstName,
    CreatedByUser.UserName AS CreatedByUserName,
    Shift.Id AS ShiftId,
    Shift.Name AS ShiftName
FROM
    CokerCard CokerCard
	INNER JOIN CokerCardConfiguration CokerCardConfiguration ON CokerCard.CokerCardConfigurationId = CokerCardConfiguration.Id
    INNER JOIN FunctionalLocation FunctionalLocation ON CokerCard.FunctionalLocationID = FunctionalLocation.Id
	LEFT JOIN WorkAssignment WorkAssignment ON CokerCard.WorkAssignmentId = WorkAssignment.Id
	INNER JOIN [User] CreatedByUser ON CokerCard.CreatedByUserId = CreatedByUser.Id
	INNER JOIN Shift Shift ON CokerCard.ShiftId = Shift.Id
WHERE
	CokerCard.CreatedDateTime <= @ToDate AND 
	CokerCard.CreatedDateTime >= @FromDate AND
	EXISTS 
	(
		SELECT Id 
		FROM IDSplitter(@Ids) 
		WHERE Id = FunctionalLocation.Id
	) AND
	CokerCard.Deleted = 0
GO

GRANT EXEC ON QueryCokerCardDTOsByFLOCIDsAndDateRange TO PUBLIC
GO