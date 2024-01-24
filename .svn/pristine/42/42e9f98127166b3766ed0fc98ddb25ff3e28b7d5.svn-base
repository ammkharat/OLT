IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'MapShiftLogToSummaryLog')
	BEGIN
		DROP PROCEDURE [dbo].MapShiftLogToSummaryLog
	END
GO

Create procedure MapShiftLogToSummaryLog
(
	@SummaryLogId bigint,
	@LogId varchar(max)
)
As

DECLARE @pos INT = 0
DECLARE @len INT = 0
DECLARE @value varchar(max)

Delete From ShiftLogAndSummaryLogMapping where SummaryLogId=@SummaryLogId

WHILE CHARINDEX(',', @LogId, @pos+1)>0
BEGIN
    set @len = CHARINDEX(',', @LogId, @pos+1) - @pos
    set @value = SUBSTRING(@LogId, @pos, @len)
    
    --PRINT @value   
    
	--If Not Exists ( select * from ShiftLogAndSummaryLogMapping where SummaryLogId=@SummaryLogId and LogId = @value)
	--Begin
	--	INSERT INTO ShiftLogAndSummaryLogMapping (SummaryLogId, LogId) Values (@SummaryLogId, @value)
	--End
	
    INSERT INTO ShiftLogAndSummaryLogMapping (SummaryLogId, LogId) Values (@SummaryLogId, @value)
    
    set @pos = CHARINDEX(',', @LogId, @pos+@len) +1
    
END
Go 

GRANT EXEC ON MapShiftLogToSummaryLog TO PUBLIC
GO
  