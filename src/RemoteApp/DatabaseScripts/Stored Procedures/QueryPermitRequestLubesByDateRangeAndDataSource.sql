IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestLubesByDateRangeAndDataSource')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestLubesByDateRangeAndDataSource
    END
GO

CREATE Procedure [dbo].QueryPermitRequestLubesByDateRangeAndDataSource
    (
		@FromDate datetime,
		@ToDate datetime,
		@DataSourceId bigint
    )
AS

SELECT
    PermitRequest.*	
FROM
    PermitRequestLubes PermitRequest	
WHERE    
	PermitRequest.DataSourceId = @DataSourceId AND
	PermitRequest.RequestedStartDate <= @ToDate AND
	PermitRequest.EndDate >= @FromDate AND
	PermitRequest.Deleted = 0	
GO

GRANT EXEC ON QueryPermitRequestLubesByDateRangeAndDataSource TO PUBLIC
GO