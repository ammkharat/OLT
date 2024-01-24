----------------------------------------------------------------------------------------
-- New status to TargetDefinition to indicate that it is associated with an invalid tag.
----------------------------------------------------------------------------------------
IF NOT EXISTS(SELECT * FROM TargetDefinitionStatus WHERE Id = 5)
BEGIN

INSERT INTO [TargetDefinitionStatus] ([Id], [Name], [Code]) VALUES
	(5, 'Invalid Tag', 'INVALID TAG')
----------------------------------------------------------------------------------------
-- Cleanup existing TargetDefinitions that are associated with an invalid tag.
----------------------------------------------------------------------------------------
UPDATE
	[TargetDefinition]
SET 		
	TargetDefinitionStatusId = 5, 
	IsActive = 0,
	LastModifiedDateTime = GETDATE(),
	LastModifiedUserId = -1		
FROM [TargetDefinition]
	INNER JOIN Tag ON [TargetDefinition].TagId = [Tag].Id
WHERE
	[Tag].Deleted = 1
AND 
	[TargetDefinition].Deleted = 0
END

GO
