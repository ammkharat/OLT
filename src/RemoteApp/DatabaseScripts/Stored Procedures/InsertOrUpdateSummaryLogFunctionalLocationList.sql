  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertOrUpdateSummaryLogFunctionalLocationList')
	BEGIN
		DROP  Procedure  InsertOrUpdateSummaryLogFunctionalLocationList
	END

GO

CREATE Procedure dbo.InsertOrUpdateSummaryLogFunctionalLocationList
	(	
	@SummaryLogId bigint
	)
AS

DELETE FROM SummaryLogFunctionalLocationList WHERE SummaryLogId = @SummaryLogId

insert into dbo.SummaryLogFunctionalLocationList (SummaryLogId, FunctionalLocationList)
SELECT l.Id 
, STUFF 
( 
  (SELECT ', ' + f.FullHierarchy
    FROM dbo.SummaryLogFunctionalLocation lfl
    INNER JOIN FunctionalLocation f on f.Id = lfl.FunctionalLocationId 
    where l.Id = lfl.SummaryLogId 
    order by f.FullHierarchy 
    FOR XML PATH('') 
  ) 
,1,2,'') as subqueryAsStringList 
FROM [SummaryLog] l
WHERE l.Id = @SummaryLogId

RETURN

GO    