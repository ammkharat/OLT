IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllTargetAlertsNeedingAttention')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllTargetAlertsNeedingAttention
	END
GO

CREATE Procedure [dbo].QueryAllTargetAlertsNeedingAttention
	(
		@CsvFlocIds VARCHAR(MAX),
		@CsvStatusIds VARCHAR(100)
	)
AS  
select 
	ta.*
from 
	targetalert ta
	INNER JOIN FunctionalLocation f ON ta.FunctionalLocationId = f.Id
	INNER JOIN IdSplitter(@CsvStatusIds) ids ON ids.Id = ta.TargetAlertStatusId
WHERE
	(
    EXISTS
    (
      SELECT ids.Id
      FROM 
		IDSplitter(@CsvFlocIds) ids
      WHERE 
		ids.Id = f.Id
    )
    OR
    EXISTS
    (
  		SELECT ids.Id
	  	FROM 
			IDSplitter(@CsvFlocIds) ids 
			INNER JOIN FunctionalLocationAncestor a ON a.AncestorId = ids.Id
		WHERE 
			a.Id = f.Id
	  )
  )
OPTION (OPTIMIZE FOR UNKNOWN)  
GO

GRANT EXEC ON QueryAllTargetAlertsNeedingAttention TO PUBLIC
GO