IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogsByFunctionalLocationList')
	BEGIN
		DROP Procedure [dbo].CountLogsByFunctionalLocationList
	END
GO

CREATE Procedure [dbo].CountLogsByFunctionalLocationList
	(
		@SiteId [bigint],
		@LogType int,
		@CsvFlocIds varchar(max)
	)
AS

SELECT
  count(distinct l.Id)
FROM [Log] l
    inner join LogFunctionalLocation lfl on lfl.LogId = l.Id
    inner join FunctionalLocation fl on fl.Id = lfl.FunctionalLocationId
WHERE l.Deleted = 0 and 
	  l.LogType = @LogType 
    and
    -- there exists one or more flocs for the site associated with this log
	  EXISTS 
	  (
  		select lfl.LogId
  		from LogFunctionalLocation lfl
  		inner join FunctionalLocation fl on fl.Id = lfl.FunctionalLocationId			
  		where lfl.LogId = l.Id and fl.SiteId = @SiteId
    )
	AND
	(
		EXISTS
		(
			SELECT ids.Id
			FROM IDSplitter(@CsvFlocIds) ids
			WHERE ids.Id = fl.Id
		)
		OR
		EXISTS
		(
			SELECT ids.Id
			FROM IDSplitter(@CsvFlocIds) ids 
			INNER JOIN FunctionalLocationAncestor a ON a.Id = ids.Id
			WHERE a.AncestorId = fl.Id
		)   
		OR
		EXISTS
		(
			SELECT ids.Id
			FROM IDSplitter(@CsvFlocIds) ids 
			INNER JOIN FunctionalLocationAncestor fla ON fla.AncestorId = ids.Id
			WHERE fla.Id = fl.Id
		)
	)	    
GO

GRANT EXEC ON CountLogsByFunctionalLocationList TO PUBLIC
GO