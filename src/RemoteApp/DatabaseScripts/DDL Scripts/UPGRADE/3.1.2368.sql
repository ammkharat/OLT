ALTER TABLE [dbo].LogHistoryADD FunctionalLocations varchar(max)GOUPDATE [dbo].LogHistorySET FunctionalLocations = fl.FullHierarchyFROM [dbo].LogHistory lh     INNER JOIN [dbo].FunctionalLocation fl ON fl.Id = lh.FunctionalLocationIdGOALTER TABLE [dbo].LogHistoryDROP COLUMN FunctionalLocationIdGO
GO
