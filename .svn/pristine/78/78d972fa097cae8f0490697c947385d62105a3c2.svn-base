-- there are some flocs in OilSands that start with OS1 that we want to delete from OilSands site.
DELETE 
	FunctionalLocationAncestor 
FROM
  FunctionalLocationAncestor
  INNER JOIN FunctionalLocation f ON FunctionalLocationAncestor.Id = f.Id
WHERE
  f.SiteId != 6
  and f.FullHierarchy like 'OS1%'
GO

delete functionallocation where siteid !=6 and FullHierarchy like 'OS1%'


GO

