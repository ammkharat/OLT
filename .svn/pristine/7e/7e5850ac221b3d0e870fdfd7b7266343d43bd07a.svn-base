IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogInBatchesByFunctionalLocationList')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogInBatchesByFunctionalLocationList
	END
GO

CREATE Procedure [dbo].QueryLogInBatchesByFunctionalLocationList
	(
		@SiteId bigint,
		@Limit int,
		@Offset int,
		@LogType int,
		@CsvFlocIds varchar(max)
	)
AS
WITH Results_CTE_1 AS
(
	SELECT
		ROW_NUMBER() OVER (PARTITION BY l.Id ORDER BY l.Id) AS LogPartitionNum,
		l.*
  FROM [Log] l
    inner join LogFunctionalLocation lfl on lfl.LogId = l.Id
    inner join FunctionalLocation fl on fl.Id = lfl.FunctionalLocationId
	WHERE l.Deleted = 0 and 
	      l.LogType = @LogType and
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
), 
Results_CTE AS
(
	SELECT
		ROW_NUMBER() OVER (ORDER BY l.Id) AS RowNum,
		l.*
  FROM Results_CTE_1 l
	WHERE l.LogPartitionNum = 1 -- duplicate records are returned but are partitioned; take the first record from each partition (by Id)
)
SELECT *
FROM Results_CTE
WHERE RowNum >= @Offset
AND RowNum < @Offset + @Limit
GO

GRANT EXEC ON QueryLogInBatchesByFunctionalLocationList TO PUBLIC
GO