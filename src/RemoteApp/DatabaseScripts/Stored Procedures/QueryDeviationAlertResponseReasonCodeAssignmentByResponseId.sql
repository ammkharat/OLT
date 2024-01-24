IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDeviationAlertResponseReasonCodeAssignmentByResponseId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDeviationAlertResponseReasonCodeAssignmentByResponseId
	END
GO

CREATE Procedure [dbo].QueryDeviationAlertResponseReasonCodeAssignmentByResponseId
(
    @ResponseId [bigint]
)
AS

SELECT *
FROM
    DeviationAlertResponseReasonCodeAssignment
WHERE
    DeviationAlertResponseId = @ResponseId
GO

GRANT EXEC ON [QueryDeviationAlertResponseReasonCodeAssignmentByResponseId] TO PUBLIC
GO