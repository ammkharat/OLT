IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllTargetDefinitionStatesAtOrBelowAGivenLevelThreeFloc')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllTargetDefinitionStatesAtOrBelowAGivenLevelThreeFloc
	END
GO

CREATE Procedure [dbo].QueryAllTargetDefinitionStatesAtOrBelowAGivenLevelThreeFloc
	(
		@UnitId bigint
	)
AS
select tstate.*
from 
  dbo.TargetDefinitionState tstate
  INNER JOIN dbo.TargetDefinition td ON tstate.TargetDefinitionId = td.Id
WHERE 
  EXISTS
  (
    SELECT f.Id
    FROM 
      dbo.FunctionalLocation f
      LEFT OUTER JOIN dbo.FunctionalLocationAncestor a ON a.Id = f.Id
    WHERE
      td.FunctionalLocationID = f.Id and
      (a.AncestorId = @UnitId or f.Id = @UnitId)
  )
GO
 
GRANT EXEC ON QueryAllTargetDefinitionStatesAtOrBelowAGivenLevelThreeFloc TO PUBLIC
GO