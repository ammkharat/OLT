IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryChildSectionFunctionLocationByParentDivisionFunctionalLocation')
	BEGIN
		DROP PROCEDURE [dbo].QueryChildSectionFunctionLocationByParentDivisionFunctionalLocation
	END
GO

CREATE Procedure [dbo].QueryChildSectionFunctionLocationByParentDivisionFunctionalLocation
(
		@DivisionValue varchar(15)
)
AS 

select 
  f.* 
from
  FunctionalLocation f
  INNER JOIN FunctionalLocationAncestor a on a.Id = f.Id and a.AncestorLevel = 1
  INNER JOIN FunctionalLocation fa on fa.Id = a.AncestorId
where 
  fa.FullHierarchy = @DivisionValue
	AND f.[Level] = 2
	AND f.Deleted = 0 
	AND f.OutOfService = 0
GO 

GRANT EXEC ON QueryChildSectionFunctionLocationByParentDivisionFunctionalLocation TO PUBLIC
GO