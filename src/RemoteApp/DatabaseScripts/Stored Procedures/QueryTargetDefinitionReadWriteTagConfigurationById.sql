 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionReadWriteTagConfigurationById')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionReadWriteTagConfigurationById
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionReadWriteTagConfigurationById
(
	@id bigint
)
AS

SELECT *
FROM 
	TargetDefinitionReadWriteTagConfiguration 
WHERE
	TargetDefinitionId=@id 
GO 

GRANT EXEC ON QueryTargetDefinitionReadWriteTagConfigurationById TO PUBLIC
GO 