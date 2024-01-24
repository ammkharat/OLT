IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogInBatches')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogInBatches
	END
GO

CREATE Procedure [dbo].QueryLogInBatches
	(
		@SiteId bigint,
		@Limit int,
		@Offset int,
		@LogType int
	)
AS

WITH Results_CTE AS
(
	SELECT
		l.*,
		ROW_NUMBER() OVER (ORDER BY Id) AS RowNum
	FROM [Log] l
	WHERE l.Deleted = 0 and 
	      l.LogType = @LogType and
		  EXISTS 
		  (
			select lfl.LogId
			from LogFunctionalLocation lfl
			inner join FunctionalLocation fl on fl.Id = lfl.FunctionalLocationId			
			where lfl.LogId = l.Id and fl.SiteId = @SiteId
		  )
)
SELECT *
FROM Results_CTE
WHERE RowNum >= @Offset
AND RowNum < @Offset + @Limit

GO

GRANT EXEC ON QueryLogInBatches TO PUBLIC
GO