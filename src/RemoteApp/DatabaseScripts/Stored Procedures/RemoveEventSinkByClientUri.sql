IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveEventSinkByClientUri')
	BEGIN
		DROP  Procedure  RemoveEventSinkByClientUri
	END

GO

CREATE Procedure [dbo].RemoveEventSinkByClientUri
	(
		@ClientUri varchar(500)
	)
AS
DELETE FROM EventSinks WHERE (ClientUri = @ClientUri)
GO

GRANT EXEC ON RemoveEventSinkByClientUri TO PUBLIC

GO


