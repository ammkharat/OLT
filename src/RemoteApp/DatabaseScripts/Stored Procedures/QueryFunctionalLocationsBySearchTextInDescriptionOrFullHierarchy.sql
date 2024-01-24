IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsBySearchTextInDescriptionOrFullHierarchy')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsBySearchTextInDescriptionOrFullHierarchy
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationsBySearchTextInDescriptionOrFullHierarchy
	(
    @SearchText varchar(max),
	@SiteId bigint,
	@CsvLevelsToSearch VARCHAR(50)
	)
AS

SELECT 
    f.Id,
    FullHierarchy
FROM 
	FunctionalLocation f
	INNER JOIN IDSplitter(@CsvLevelsToSearch) levels ON levels.Id = f.[Level]
WHERE 
	Deleted = 0
	and OutOfService = 0
    and (upper(Description) like upper('%' + Replace(@SearchText, ' ', '%') + '%') or
		 upper(FullHierarchy) like upper('%' + Replace(@SearchText, ' ', '%') + '%'))
	and SiteId=@SiteId 
ORDER BY
    FullHierarchy
GO 

GRANT EXEC ON [QueryFunctionalLocationsBySearchTextInDescriptionOrFullHierarchy] TO PUBLIC
GO