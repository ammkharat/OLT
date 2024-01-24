IF EXISTS (SELECT * FROM sysobjects WHERE type = 'FN' AND name = 'DatePartCompare')
	BEGIN
		DROP  Function  [dbo].DatePartCompare
	END
GO

CREATE Function [dbo].DatePartCompare (@dateA datetime, @dateB datetime)  
Returns smallint AS

BEGIN
  IF (datepart(year, @dateA) > datepart(year, @dateB))
    RETURN 1
  IF (datepart(year, @dateA) < datepart(year, @dateB))
    RETURN -1
    
  IF (datepart(month,@dateA) > datepart(month,@dateB))
    RETURN 1
  IF (datepart(month,@dateA) < datepart(month,@dateB))
    RETURN -1

  IF (datepart(day,@dateA) > datepart(day,@dateB))
    RETURN 1
  IF (datepart(day,@dateA) < datepart(day,@dateB))
    RETURN -1
    
  RETURN 0
END  