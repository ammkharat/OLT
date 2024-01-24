IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionsAlreadyWritingToTag')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionsAlreadyWritingToTag
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionsAlreadyWritingToTag
(
    @TargetDefinitionId bigint,
    @TagDirectionId bigint,
    @TagId bigint
)
AS

SELECT     
	td.*
FROM         
	TargetDefinition td
	INNER JOIN TargetDefinitionReadWriteTagConfiguration rwc 
	ON rwc.TargetDefinitionId = td.Id	
WHERE     
	(	(rwc.MaxDirectionId = @TagDirectionId AND rwc.MaxTagId = @TagId) 
	OR  (rwc.MinDirectionId = @TagDirectionId AND rwc.MinTagId = @TagId) 
	OR  (rwc.TargetDirectionId = @TagDirectionId AND rwc.TargetTagId = @TagId) 
	OR  (rwc.GapUnitValueDirectionId = @TagDirectionId AND rwc.GapUnitValueTagId = @TagId)
	) 
	AND (@TargetDefinitionId IS NULL OR td.Id <> @TargetDefinitionId)
	AND td.Deleted = 0
GO

GRANT EXEC ON QueryTargetDefinitionsAlreadyWritingToTag TO PUBLIC
GO