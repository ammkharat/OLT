 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveGasTestElementInfo')
	BEGIN
		DROP  Procedure  RemoveGasTestElementInfo
	END

GO

CREATE Procedure [dbo].RemoveGasTestElementInfo
	(
			@id bigint
	)
AS

DELETE FROM [GasTestElementInfo]
WHERE Id = @Id
GO

GRANT EXEC ON RemoveGasTestElementInfo TO PUBLIC

GO  