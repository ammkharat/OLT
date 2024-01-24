
    
 -- exec QueryPermitRequestFortHillsByDateRangeAndDataSource '07/19/2019', '07/19/2019', 1  
IF OBJECT_ID('QueryPermitRequestFortHillsByDateRangeAndDataSource', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsByDateRangeAndDataSource
GO   
CREATE Procedure [dbo].QueryPermitRequestFortHillsByDateRangeAndDataSource      
    (      
  @FromDate datetime,      
  @ToDate datetime,      
  @DataSourceId bigint      
    )      
AS      
      
SELECT      
    PermitRequest.*       
FROM      
    PermitRequestFortHills PermitRequest       
WHERE          
 PermitRequest.DataSourceId = @DataSourceId AND      
 PermitRequest.RequestedStartDate <= @ToDate AND      
 PermitRequest.RequestedEndDate >= @FromDate AND      
 PermitRequest.Deleted = 0      
     
 GRANT EXEC ON [QueryPermitRequestFortHillsByDateRangeAndDataSource] TO PUBLIC   
   
   
   
   
   