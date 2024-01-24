IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTrainingBlocksByFunctionalLocations')
	BEGIN
		DROP PROCEDURE [dbo].QueryTrainingBlocksByFunctionalLocations
	END
GO

CREATE Procedure [dbo].QueryTrainingBlocksByFunctionalLocations
	(
		@CsvFLOCIds varchar(max)
	)
AS

WITH TrainingBlock_Id_CTE (TrainingBlockId)
AS 
(
SELECT 
  DISTINCT tb.Id
FROM
  TrainingBlock tb
WHERE
	tb.Deleted = 0 AND
	(
		EXISTS
		(
		-- Floc of block matches one of the passed in flocs
		select tbfl.TrainingBlockId From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN TrainingBlockFunctionalLocation tbfl ON ids.Id = tbfl.FunctionalLocationId
		WHERE tbfl.TrainingBlockId = tb.Id
		)
		OR EXISTS
		(
		  -- Floc of block is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		  select tbfl.TrainingBlockId from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		  INNER JOIN TrainingBlockFunctionalLocation tbfl ON a.AncestorId = tbfl.FunctionalLocationId
		  WHERE tbfl.TrainingBlockId = tb.Id
		)
		OR EXISTS
		(
		   -- Floc of block is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select tbfl.TrainingBlockId from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.AncestorId
		  INNER JOIN TrainingBlockFunctionalLocation tbfl ON a.Id = tbfl.FunctionalLocationId
		  WHERE tbfl.TrainingBlockId = tb.Id
		)
	)
)
SELECT
    tb.*
FROM
    TrainingBlock tb
    inner join TrainingBlock_Id_CTE ON TrainingBlock_Id_CTE.TrainingBlockId = tb.Id
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC ON QueryTrainingBlocksByFunctionalLocations TO PUBLIC
GO