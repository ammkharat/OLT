IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryGapReasonsByShiftAndDateRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryGapReasonsByShiftAndDateRange
    END
GO

CREATE Procedure [dbo].QueryGapReasonsByShiftAndDateRange
    (
        @FlocIds VARCHAR(MAX),
        @CreatedShiftPatternId BIGINT,
        @FromDateTime DATETIME,
        @ToDateTime DATETIME       
    )
AS
SELECT
	s.Id as ShiftId,
	coalesce(funit.FullHierarchy, f.FullHierarchy) as TargetAlertUnitName,
	coalesce(funit.Description, f.Description) as TargetAlertUnitDescription,
	f.FullHierarchy as TargetAlertFunctionalLocation,
	f.Description as TargetAlertFunctionalLocationDescription,
	ta.TargetName as TargetAlertName,
	tag.Name as TagName,
	u.Username,
	u.Firstname,
	u.Lastname,
	c.CreatedDate as RespondedDateTime,
	tar.TargetGapReasonId,
	c.[Text] as TargetGapReasonComment
FROM 
	TargetAlertResponse tar 
	INNER JOIN TargetAlert ta ON tar.TargetAlertId = ta.[Id]
	INNER JOIN FunctionalLocation f ON ta.FunctionalLocationId = f.Id
	LEFT JOIN FunctionalLocationAncestor a ON f.Id = a.Id and a.AncestorLevel = 3
	LEFT JOIN FunctionalLocation funit ON a.AncestorId = funit.Id 
	INNER JOIN Tag tag ON ta.TagID = tag.Id
	INNER JOIN Comment c ON tar.CommentId = c.[Id]
	INNER JOIN [User] u ON u.Id = c.CreatedUserId
	LEFT OUTER JOIN Shift s ON tar.CreatedShiftPatternId = s.Id	
WHERE	
	c.CreatedDate BETWEEN @FromDateTime AND @ToDateTime
	AND tar.CreatedShiftPatternId = @CreatedShiftPatternId
	and tar.TargetGapReasonId is not null
  and
      EXISTS
      (
        -- Floc of Target Alert matches one of the passed in flocs
        select ta1.Id From IDSplitter(@FlocIds) ids
        INNER JOIN TargetAlert ta1 ON ta1.FunctionalLocationID = ids.Id
        WHERE ta1.Id = ta.Id
        UNION ALL
        -- Floc of Target Alert is child of one of the passed in flocs (look down the floc tree from my selected flocs)
        select ta1.Id
        From FunctionalLocationAncestor a 
        INNER JOIN IDSplitter(@FlocIds) ids ON ids.Id = a.ancestorid
        INNER JOIN TargetAlert ta1 ON a.Id = ta1.FunctionalLocationId
        WHERE ta1.Id = ta.Id
      )
OPTION (OPTIMIZE FOR UNKNOWN)		  
GO

GRANT EXEC ON [QueryGapReasonsByShiftAndDateRange] TO PUBLIC
GO