IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationOperationalModeById')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationOperationalModeById
	END
GO

CREATE Procedure [dbo].[QueryFunctionalLocationOperationalModeById]
	(
		@Id bigint
	)
AS

SELECT
	*
FROM
	FunctionalLocationOperationalMode
WHERE
	UnitId = @Id
GO

GRANT EXEC ON [QueryFunctionalLocationOperationalModeById] TO PUBLIC
GO