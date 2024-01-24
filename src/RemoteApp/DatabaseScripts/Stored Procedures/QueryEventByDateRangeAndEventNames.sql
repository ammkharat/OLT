IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryEventByDateRangeAndEventNames')
	BEGIN
		DROP PROCEDURE [dbo].QueryEventByDateRangeAndEventNames
	END
GO

CREATE Procedure dbo.QueryEventByDateRangeAndEventNames
	(
	@FromDateTime datetime,
	@ToDateTime datetime,
	@CsvEventNames varchar(max)
	)
AS
SELECT e.*
FROM Event e
INNER JOIN VarcharSplitter(@CsvEventNames) Names on Names.String = e.Name
WHERE @FromDateTime <= DateTime and
      DateTime <= @ToDateTime	  
	  
GO

GRANT EXEC ON QueryEventByDateRangeAndEventNames TO PUBLIC
GO