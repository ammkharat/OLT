IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationByWorkAssignmentIdForRestrictionFlocs')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationByWorkAssignmentIdForRestrictionFlocs
	END
GO

CREATE Procedure [dbo].QueryFunctionalLocationByWorkAssignmentIdForRestrictionFlocs
(
	@WorkAssignmentId bigint
)

AS
	SELECT f.*
	FROM
		FunctionalLocation f,
		RestrictionWorkAssignmentConfigurationFunctionalLocation r
	WHERE
		r.WorkAssignmentId = @WorkAssignmentId
		and f.Id = r.FunctionalLocationId
		and f.Deleted = 0
GO

GRANT EXEC ON [QueryFunctionalLocationByWorkAssignmentIdForRestrictionFlocs] TO PUBLIC
GO