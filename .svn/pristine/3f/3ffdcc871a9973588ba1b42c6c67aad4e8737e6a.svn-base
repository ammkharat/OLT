IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QuerySummaryLogHistoriesById
	END
GO

CREATE Procedure [dbo].QuerySummaryLogHistoriesById
	(
	@Id bigint
	)
AS
SELECT * FROM SummaryLogHistory WHERE Id=@Id ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON QuerySummaryLogHistoriesById TO PUBLIC
GO