  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertOrUpdateLogFunctionalLocationList')
	BEGIN
		DROP  Procedure  InsertOrUpdateLogFunctionalLocationList
	END

GO

CREATE Procedure dbo.InsertOrUpdateLogFunctionalLocationList
	(	
	@LogId bigint
	)
AS

DELETE FROM LogFunctionalLocationList WHERE LogId = @LogId

insert into dbo.LogFunctionalLocationList (LogId, FunctionalLocationList)
SELECT l.Id 
, STUFF 
( 
  (SELECT ', ' + f.FullHierarchy
    FROM dbo.LogFunctionalLocation lfl 
    INNER JOIN FunctionalLocation f on f.Id = lfl.FunctionalLocationId 
    where l.Id = lfl.LogId 
    order by f.FullHierarchy 
    FOR XML PATH('') 
  ) 
,1,2,'') as subqueryAsStringList 
FROM [Log] l
WHERE l.Id = @LogId

RETURN

GO    