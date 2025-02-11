
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMudsByDateRangeAndDataSource')
	BEGIN
		DROP Procedure [dbo].QueryPermitRequestMudsByDateRangeAndDataSource
	END
GO

CREATE Procedure [dbo].[QueryPermitRequestMudsByDateRangeAndDataSource]  
    (  
  @FromDate datetime,  
  @ToDate datetime,  
  @DataSourceId bigint  
    )  
AS  
  
SELECT  
    PermitRequest.*   
FROM  
    PermitRequestMuds PermitRequest   
WHERE      
 PermitRequest.SourceId = @DataSourceId AND  
 PermitRequest.StartDate <= @ToDate AND  
 PermitRequest.EndDate >= @FromDate AND  
 PermitRequest.Deleted = 0
GO

GRANT EXEC ON QueryPermitRequestMudsByDateRangeAndDataSource TO PUBLIC
GO

