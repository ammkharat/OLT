IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByWorkAssignmentId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsByWorkAssignmentId
	END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByWorkAssignmentId
(
	@WorkAssignmentId bigint
)

AS
SELECT f.*
FROM
	FunctionalLocation f
	INNER JOIN WorkAssignmentFunctionalLocation o
		ON 	f.Id = o.FunctionalLocationId
WHERE
	o.WorkAssignmentId = @WorkAssignmentId
	and f.Deleted = 0
GO

GRANT EXEC ON [QueryFunctionalLocationsByWorkAssignmentId] TO PUBLIC
GO