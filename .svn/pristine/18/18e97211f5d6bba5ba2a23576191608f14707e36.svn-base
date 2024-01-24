 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveGasTestElement')
	BEGIN
		DROP  Procedure  RemoveGasTestElement
	END

GO

CREATE Procedure [dbo].RemoveGasTestElement
	(
			@id bigint
	)
AS

DELETE FROM [WorkPermitGasTestElementInfo]
WHERE Id = @Id
GO

GRANT EXEC ON RemoveGasTestElement TO PUBLIC

GO 