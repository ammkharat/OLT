IF EXISTS (SELECT * FROM sysobjects WHERE type = 'FN' AND name = 'DatePartEquals')
	BEGIN
		DROP  Function  [dbo].DatePartEquals
	END
GO

CREATE Function [dbo].DatePartEquals (@dateA datetime, @dateB datetime)  
Returns bit AS

BEGIN
  IF (dbo.DatePartCompare(@dateA, @dateB) = 0)
    RETURN 1
  
  RETURN 0
END 