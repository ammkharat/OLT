IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDeviationAlertReportDTOsByDateRangeAndParentFloc')
	BEGIN
		DROP PROCEDURE [dbo].QueryDeviationAlertReportDTOsByDateRangeAndParentFloc
	END

GO

CREATE Procedure [dbo].QueryDeviationAlertReportDTOsByDateRangeAndParentFloc
(
    @Ids varchar(MAX),
	@FromDate datetime,
	@ToDate datetime
)

AS

SELECT
    da.Id,	
	da.RestrictionDefinitionName,
    AlertFloc.FullHierarchy as AlertFlocFullHierarchy,
	mvtag.Name as MeasurementTagName,
	da.MeasurementValue,
	ptvtag.Name as ProductionTargetTagName,
	da.ProductionTargetValue,
	da.StartDateTime,
	da.EndDateTime,
	da.IsOnlyVisibleOnReports as IsHiddenDeviation,
    reasonCode.Name as ReasonCodeName,
    assignment.AssignedAmount,
	assignment.PlantState,
	assignment.Comments as ReasonCodeAssignmentComments,
    reasonCodeFloc.FullHierarchy as ReasonCodeFlocFullHierarchy,
    reasonCodeFloc.Description as ReasonCodeFlocDescription
FROM
    DeviationAlert da
    INNER JOIN FunctionalLocation AlertFloc ON AlertFloc.Id = da.FunctionalLocationID
	INNER JOIN Tag mvtag ON mvtag.Id = da.MeasurementValueTagId
    LEFT OUTER JOIN Tag ptvtag ON ptvtag.Id = da.ProductionTargetValueTagId
    LEFT OUTER JOIN DeviationAlertResponse dar ON da.DeviationAlertResponseId = dar.Id
    LEFT OUTER JOIN DeviationAlertResponseReasonCodeAssignment assignment ON dar.Id = assignment.DeviationAlertResponseId
    LEFT OUTER JOIN dbo.RestrictionReasonCode reasonCode ON  assignment.RestrictionReasonCodeId = reasonCode.Id
    LEFT OUTER JOIN FunctionalLocation reasonCodeFloc ON assignment.ReasonCodeFunctionalLocationId = reasonCodeFloc.Id
WHERE     
	    da.StartDateTime >= @FromDate 
    AND da.StartDateTime < @ToDate
	AND EXISTS
	(
		-- one of the query flocs is the deviation alert floc
		select Id
		from IDSplitter(@Ids)
		where da.FunctionalLocationID = Id
		UNION ALL
		-- one of the query flocs is a parent of the deviation alert floc
		select Relationship.Id 
		from FunctionalLocationAncestor Relationship
		INNER JOIN IDSplitter(@Ids) QueryIds on Relationship.AncestorId = QueryIds.Id
		where da.FunctionalLocationID = Relationship.Id
	)
ORDER BY
    da.RestrictionDefinitionName, da.StartDateTime
OPTION (OPTIMIZE FOR UNKNOWN)
GO

GRANT EXEC ON [QueryDeviationAlertReportDTOsByDateRangeAndParentFloc] TO PUBLIC
GO