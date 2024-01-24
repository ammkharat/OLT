
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogs')
	BEGIN
		DROP Procedure [dbo].CountLogs
	END
GO
--test
CREATE Procedure [dbo].CountLogs
	(
		@SiteId [bigint],
		@LogType int
	)
AS

SELECT
	COUNT(l.Id)
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
GO

GRANT EXEC ON CountLogs TO PUBLIC
GO