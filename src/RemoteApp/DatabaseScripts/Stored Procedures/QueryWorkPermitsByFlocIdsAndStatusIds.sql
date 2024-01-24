IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitsByFlocIdsAndStatusIds')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitsByFlocIdsAndStatusIds
    END
GO

CREATE Procedure [dbo].QueryWorkPermitsByFlocIdsAndStatusIds
    (
        @CsvFLOCIds varchar(MAX),
        @CsvStatusIds varchar(MAX)
    )
AS

SELECT 
	WorkPermit.*,
	FunctionalLocation.*
FROM
    WorkPermit workPermit
    INNER JOIN FunctionalLocation functionalLocation ON workPermit.FunctionalLocationId = functionalLocation.[Id]
    INNER JOIN IDSplitter( @CsvStatusIds ) ids ON ids.Id = workPermit.WorkPermitStatusId
WHERE
    workPermit.Deleted = 0 AND
    (
      EXISTS
      (
		  -- Floc of permit matches one of the passed in flocs
		  select ids.Id
		  from IDSplitter(@CsvFLOCIds) ids
		  where ids.Id = functionalLocation.Id
      )
      OR EXISTS
      (
  		-- Floc of permit is child of one of the passed in flocs (look down the floc tree from my selected flocs)
	  	select ids.Id
		  from FunctionalLocationAncestor a
		  inner join IDSplitter(@CsvFLOCIds) ids on ids.Id = a.AncestorId
		  where a.Id = functionalLocation.Id
	    )
    )
OPTION (OPTIMIZE FOR UNKNOWN)  		
GO

GRANT EXEC ON QueryWorkPermitsByFlocIdsAndStatusIds TO PUBLIC
GO