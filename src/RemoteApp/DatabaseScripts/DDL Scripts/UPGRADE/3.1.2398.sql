

ALTER TABLE [dbo].LogDefinitionHistory
ADD FunctionalLocations varchar(max)

GO

UPDATE [dbo].LogDefinitionHistory
SET FunctionalLocations = fl.FullHierarchy
FROM [dbo].LogDefinitionHistory ldh
     INNER JOIN [dbo].FunctionalLocation fl ON fl.Id = ldh.FunctionalLocationId

GO

ALTER TABLE [dbo].LogDefinitionHistory
DROP COLUMN FunctionalLocationId

GO

GO

GO
