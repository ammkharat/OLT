IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationByFullHierarchyIncludeDeletedToTestExistence')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationByFullHierarchyIncludeDeletedToTestExistence
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationByFullHierarchyIncludeDeletedToTestExistence
	(
	@FullHierarchy varchar(90)
	)
AS
SELECT
	*
FROM
	FunctionalLocation
WHERE
	FullHierarchy = @FullHierarchy
GO

GRANT EXEC ON [QueryFunctionalLocationByFullHierarchyIncludeDeletedToTestExistence] TO PUBLIC
GO