IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveCokerCardConfiguration')
	BEGIN
		DROP  Procedure  RemoveCokerCardConfiguration
	END

GO

CREATE Procedure [dbo].RemoveCokerCardConfiguration
	(
		@id bigint		
	)
AS

UPDATE CokerCardConfiguration SET Deleted = 1 WHERE Id=@Id
GO

GRANT EXEC ON RemoveCokerCardConfiguration TO PUBLIC

GO