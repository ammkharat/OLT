IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByWorkAssignmentIdForWorkPermits')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsByWorkAssignmentIdForWorkPermits
	END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByWorkAssignmentIdForWorkPermits
(
	@WorkAssignmentId bigint
)

AS
	SELECT f.*
	FROM
		FunctionalLocation f
	INNER JOIN
		WorkPermitFunctionalLocationConfiguration o ON f.Id = o.FunctionalLocationId
	WHERE
		o.WorkAssignmentId = @WorkAssignmentId
		and f.Deleted = 0
GO

GRANT EXEC ON [QueryFunctionalLocationsByWorkAssignmentIdForWorkPermits] TO PUBLIC
GO