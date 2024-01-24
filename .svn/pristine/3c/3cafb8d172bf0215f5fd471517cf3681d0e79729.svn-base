IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMontrealHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestMontrealHistoriesById
	END
GO

CREATE Procedure [dbo].QueryPermitRequestMontrealHistoriesById
	(
	@Id bigint
	)
AS
SELECT * 
FROM PermitRequestMontrealHistory 
WHERE Id=@Id 
ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON [QueryPermitRequestMontrealHistoriesById] TO PUBLIC
GO