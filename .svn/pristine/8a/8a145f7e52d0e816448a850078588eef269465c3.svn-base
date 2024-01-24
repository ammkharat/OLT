IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VFunctionalLocationChildrenCount')
BEGIN
	DROP VIEW VFunctionalLocationChildrenCount
END
GO

CREATE VIEW [dbo].VFunctionalLocationChildrenCount WITH SCHEMABINDING
AS
	SELECT 
	  a.AncestorId as ParentId, 
	  count_big(*) AS NumChildren 
	From
	  [dbo].FunctionalLocation c
	  INNER JOIN 
		[dbo].FunctionalLocationAncestor a 
      ON c.Id = a.Id
		  and (a.[AncestorLevel] +1) = c.[Level]
	WHERE
	  c.Deleted = 0
	  and c.OutOfService = 0
	Group By a.AncestorId
GO

IF ObjectProperty(object_id('VFunctionalLocationChildrenCount'),'IsIndexable') = 1
BEGIN
	CREATE UNIQUE CLUSTERED INDEX VFunctionalLocationChildrenCountIdIndex ON VFunctionalLocationChildrenCount(ParentId)
END

GRANT SELECT ON VFunctionalLocationChildrenCount TO PUBLIC
GO