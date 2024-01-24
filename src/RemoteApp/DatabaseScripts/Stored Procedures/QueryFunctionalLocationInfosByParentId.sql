IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationInfosByParentId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationInfosByParentId
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationInfosByParentId
	(
	@ParentId int
	)
AS
SELECT 
    Floc.*, 
    COALESCE(PArentChildrenCount.NumChildren, 0) as NumChildren 
FROM FunctionalLocation Floc
  INNER JOIN FunctionalLocationAncestor a
      ON Floc.Id = a.Id
		  and (a.AncestorLevel + 1) = Floc.[Level]
	LEFT OUTER JOIN VFunctionalLocationChildrenCount ParentChildrenCount
	  ON ParentChildrenCount.ParentId = a.Id
	WHERE a.AncestorId = @ParentId
		AND Floc.Deleted = 0
		AND Floc.OutOfService = 0
ORDER BY
    FullHierarchy
GO

GRANT EXEC ON [QueryFunctionalLocationInfosByParentId] TO PUBLIC
GO