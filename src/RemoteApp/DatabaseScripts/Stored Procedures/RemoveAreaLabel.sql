IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveAreaLabel')
	BEGIN
		DROP  Procedure  RemoveAreaLabel
	END

GO

CREATE Procedure [dbo].RemoveAreaLabel
	(
		@Id bigint
	)
AS

UPDATE AreaLabel
SET [Deleted] = 1
WHERE Id=@Id

GO

GRANT EXEC ON RemoveAreaLabel TO PUBLIC

GO


