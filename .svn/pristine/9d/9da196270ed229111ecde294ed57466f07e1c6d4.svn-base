IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationOpModeDTOByLevelThreeAndBelow')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationOpModeDTOByLevelThreeAndBelow
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationOpModeDTOByLevelThreeAndBelow
(
	@Id bigint
)
AS

declare @Level tinyint
SET @Level = (SELECT [Level] from FunctionalLocation where Id = @Id)

IF (@Level = 3)
  BEGIN
    SELECT 	
    	floc.FullHierarchy, floc.Description, opMode.* 
    FROM 
    	 FunctionalLocation floc
    	 INNER JOIN FunctionalLocationOperationalMode opMode 
    		ON floc.Id = opMode.UnitId
    WHERE 
    	opMode.UnitId = @Id
    order by 
    	floc.FullHierarchy
  END
IF (@Level > 3)
  BEGIN
    SELECT 	
    	floc.FullHierarchy, floc.Description, opMode.* 
    FROM 
    	 FunctionalLocation floc
       INNER JOIN FunctionalLocationAncestor a
        ON floc.Id = a.Id and a.AncestorLevel = 3
    	 INNER JOIN FunctionalLocationOperationalMode opMode 
    		ON a.AncestorId = opMode.UnitId
    WHERE 
    	floc.Id = @Id
    order by 
    	floc.FullHierarchy
  END
GO

GRANT EXEC ON [QueryFunctionalLocationOpModeDTOByLevelThreeAndBelow] TO PUBLIC
GO