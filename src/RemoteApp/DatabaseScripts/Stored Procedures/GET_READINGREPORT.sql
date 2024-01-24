

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GET_READINGREPORT')
	BEGIN
		DROP Procedure [dbo].GET_READINGREPORT
	END
GO

CREATE PROC [dbo].[GET_READINGREPORT]    
(    
 @ActionItemDefinitionId INT,
  @StartDate Date,  
  @EndDate Date
 )
 
 AS
IF OBJECT_ID('tempdb..#T') IS NOT NULL
    DROP TABLE #T
    
IF OBJECT_ID('tempdb..#TDATA') IS NOT NULL
    DROP TABLE #TDATA

Declare @ActionItemDefinationName Nvarchar(200);

SELECT @ActionItemDefinationName=Name FROM ActionItemDefinition WHERE Id=@ActionItemDefinitionId --113056

Select CustomFieldId,DisplayField,ActionItemCustomFieldName ,CAST(TimeStamp As Varchar(25)) as Date,BatchNumber,Comment into #T from ActionItemResponseTracker A
 where ActionItemDefinitionId=@ActionItemDefinitionId and  TimeStamp between @StartDate and DATEADD(day,1,@EndDate) --113056 
order by  BatchNumber

DECLARE @Head VARCHAR(MAX);
DECLARE @Batch VARCHAR(MAX);
DECLARE @TABLESCRIPT VARCHAR(MAX);
DECLARE @COLSCRIPT VARCHAR(MAX);
DECLARE @INT VARCHAR(MAX);
SET @INT=1
DECLARE vendor_cursor CURSOR FOR 
Select  BatchNumber,max(date+'_'+CAST(BatchNumber AS VARCHAR)) from  #T group by BatchNumber  
--select distinct date+'_'+CAST(BatchNumber AS VARCHAR) from #T 
 
 SET @TABLESCRIPT='CREATE #T(ActionItemCustomFieldName VARCHAR(4000),' 
  SET @COLSCRIPT='' 
OPEN vendor_cursor  
  
FETCH NEXT FROM vendor_cursor   
INTO @Batch,@Head  
  
  
WHILE @@FETCH_STATUS = 0  
BEGIN  
SET @COLSCRIPT=@COLSCRIPT +CASE WHEN @COLSCRIPT='' THEN '[' else ',[' end +@Head+'] VARCHAR(20),COMMENT_'+CAST(@INT AS VARCHAR) +' VARCHAR(4000)';
-- Print @COLSCRIPT  
SET @INT=@INT+1
FETCH NEXT FROM vendor_cursor   
INTO @Batch,@Head    
END   
CLOSE vendor_cursor;  
DEALLOCATE vendor_cursor
CREATE TABLE  #TDATA(ActionItemCustomFieldName VARCHAR(4000))
--SET @TABLESCRIPT='CREATE TABLE  #TDATA(ActionItemCustomFieldName VARCHAR(4000),'+@COLSCRIPT+')';
SET @TABLESCRIPT='ALTER TABLE #TDATA Add '+@COLSCRIPT;
print @TABLESCRIPT

--Inser Tag Name in table
Declare @TAGINSERT VARCHAR(400)
SET @TAGINSERT=' INSERT INTO #TDATA(ActionItemCustomFieldName) SELECT DISTINCT ActionItemCustomFieldName from #T'


DECLARE @statement NVARCHAR(4000)
SET @statement=@TABLESCRIPT +@TAGINSERT
EXEC sp_executesql @statement 





DECLARE @COL NVARCHAR(200)
DECLARE @INT1 INT
SET @INT1=0
DECLARE COL_cursor CURSOR FOR   
select NAME from tempdb.sys.columns where object_id =
object_id('tempdb..#TDATA') AND NAME NOT like 'COMMENT%';
 
  
OPEN COL_cursor  
  
FETCH NEXT FROM COL_cursor   
INTO @COL  
  
  
WHILE @@FETCH_STATUS = 0  
BEGIN  
--PRINT @COL
Declare @UScript Nvarchar(MAX) 

SET @UScript='Update  A
SET ['+ @COL+']=(SELECT TOP 1 DisplayField from #T B WHERE B.ActionItemCustomFieldName=A.ActionItemCustomFieldName AND CAST(B.Date As Varchar(19))+''_''+CAST(BatchNumber AS VARCHAR)='''+@COL+''''+')'

IF EXISTS(select 1 from tempdb.sys.columns where object_id =object_id('tempdb..#TDATA') AND name='COMMENT_'+CAST(@INT1 AS VARCHAR) )
 BEGIN 
 SET @UScript=@UScript + ',[COMMENT_'+CAST(@INT1 AS VARCHAR) +']=(SELECT TOP 1 COMMENT from #T B WHERE B.ActionItemCustomFieldName=A.ActionItemCustomFieldName AND CAST(B.Date As Varchar(19))+''_''+CAST(BatchNumber AS VARCHAR)='''+@COL+''''+')'
 END 
SET @UScript=@UScript+'FROm #TDATA A'

IF(@INT1>0)
BEGIN
--print @UScript
EXEC sp_executesql @UScript
END 
SET @INT1=@INT1+1
 FETCH NEXT FROM COL_cursor   
INTO @COL    
END   
CLOSE COL_cursor;  
DEALLOCATE COL_cursor

SELECT *,@ActionItemDefinationName As 'ActionItem Name' FROM #TDATA












