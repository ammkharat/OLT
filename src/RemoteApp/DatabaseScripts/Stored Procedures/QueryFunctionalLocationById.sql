IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationById')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationById
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationById
	(
	@id bigint
	)
AS
SELECT * FROM FunctionalLocation WHERE Id=@Id
GO

GRANT EXEC ON [QueryFunctionalLocationById] TO PUBLIC
GO