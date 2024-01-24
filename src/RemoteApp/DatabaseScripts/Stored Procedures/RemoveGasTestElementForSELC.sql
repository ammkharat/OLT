 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveGasTestElementForSELC')
	BEGIN
		DROP  Procedure  RemoveGasTestElementForSELC
	END

GO

CREATE Procedure [dbo].RemoveGasTestElementForSELC
	(
			@id bigint
	)
AS

DELETE FROM [WorkPermitGasTestElementInfoForSELC]
WHERE Id = @Id
GO

GRANT EXEC ON RemoveGasTestElementForSELC TO PUBLIC

GO 