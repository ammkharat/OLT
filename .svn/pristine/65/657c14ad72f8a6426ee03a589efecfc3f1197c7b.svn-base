IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByLogId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsByLogId
	END
GO
					 
CREATE Procedure dbo.QueryFunctionalLocationsByLogId
	(
	@LogId bigint
	)
AS
SELECT fl.*
FROM FunctionalLocation fl
INNER JOIN LogFunctionalLocation lfl ON lfl.FunctionalLocationId = fl.Id AND lfl.LogId = @LogId
GO

GRANT EXEC ON [QueryFunctionalLocationsByLogId] TO PUBLIC
GO