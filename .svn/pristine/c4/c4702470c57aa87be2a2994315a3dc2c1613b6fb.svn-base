IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPlantById')
	BEGIN
		DROP PROCEDURE [dbo].QueryPlantById
	END
GO

CREATE Procedure [dbo].QueryPlantById
	(
		@id int
	)
AS

SELECT *
FROM [Plant]
WHERE Id = @id
GO

GRANT EXEC ON QueryPlantById TO PUBLIC
GO 