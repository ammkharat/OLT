IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllActionItemsNeedingAttention')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllActionItemsNeedingAttention
	END
GO

CREATE Procedure [dbo].QueryAllActionItemsNeedingAttention
	(
		@CsvFlocIds VARCHAR(MAX)
	)
AS
select 
	ai.*
from 
	actionitem ai
where 
	ai.Deleted = 0 and
	ai.ActionItemStatusId != 4 and
	(
    EXISTS
    (
      SELECT ai.Id
      FROM 
		ActionItemFunctionalLocation aifl
		INNER JOIN IDSplitter(@CsvFlocIds) ids on ids.Id = aifl.FunctionalLocationId
      WHERE 
		aifl.ActionItemId = ai.Id
    )
    OR
    EXISTS
    (
  		SELECT ai.Id
	  	FROM 
			ActionItemFunctionalLocation aifl
			INNER JOIN FunctionalLocationAncestor a ON a.Id = aifl.FunctionalLocationId
			INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.AncestorId
		WHERE 
			ai.Id = aifl.ActionItemId
	  )
  )
OPTION (OPTIMIZE FOR UNKNOWN)
GO 

GRANT EXEC ON QueryAllActionItemsNeedingAttention TO PUBLIC
GO