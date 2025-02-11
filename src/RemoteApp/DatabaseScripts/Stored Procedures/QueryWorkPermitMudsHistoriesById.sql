
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMudsHistoriesById')
	BEGIN
		DROP Procedure [dbo].QueryWorkPermitMudsHistoriesById
	END
GO

CREATE Procedure [dbo].[QueryWorkPermitMudsHistoriesById]
	(
	@Id bigint
	)
AS
SELECT * FROM WorkPermitMudsHistory WHERE Id=@Id ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON QueryWorkPermitMudsHistoriesById TO PUBLIC
GO
