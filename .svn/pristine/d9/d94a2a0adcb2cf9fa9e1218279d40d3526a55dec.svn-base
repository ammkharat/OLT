IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMontrealHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitMontrealHistoriesById
	END
GO

CREATE Procedure [dbo].QueryWorkPermitMontrealHistoriesById
	(
	@Id bigint
	)
AS
SELECT * FROM WorkPermitMontrealHistory WHERE Id=@Id ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON QueryWorkPermitMontrealHistoriesById TO PUBLIC
GO