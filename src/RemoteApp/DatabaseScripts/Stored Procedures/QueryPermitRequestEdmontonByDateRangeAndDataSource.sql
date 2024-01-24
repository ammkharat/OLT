IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByDateRangeAndDataSource')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByDateRangeAndDataSource
    END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonByDateRangeAndDataSource
    (
		@FromDate datetime,
		@ToDate datetime,
		@DataSourceId bigint
    )
AS

SELECT
    PermitRequest.*	
FROM
    PermitRequestEdmonton PermitRequest	
WHERE    
	PermitRequest.DataSourceId = @DataSourceId AND
	PermitRequest.RequestedStartDate <= @ToDate AND
	PermitRequest.EndDate >= @FromDate AND
	PermitRequest.Deleted = 0	
GO

GRANT EXEC ON QueryPermitRequestEdmontonByDateRangeAndDataSource TO PUBLIC
GO