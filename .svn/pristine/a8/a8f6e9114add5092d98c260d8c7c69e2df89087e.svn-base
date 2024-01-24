IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMontrealByDateRangeAndDataSource')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestMontrealByDateRangeAndDataSource
    END
GO

CREATE Procedure [dbo].QueryPermitRequestMontrealByDateRangeAndDataSource
    (
		@FromDate datetime,
		@ToDate datetime,
		@DataSourceId bigint
    )
AS

SELECT
    PermitRequest.*	
FROM
    PermitRequestMontreal PermitRequest	
WHERE    
	PermitRequest.SourceId = @DataSourceId AND
	PermitRequest.StartDate <= @ToDate AND
	PermitRequest.EndDate >= @FromDate AND
	PermitRequest.Deleted = 0	
GO

GRANT EXEC ON QueryPermitRequestMontrealByDateRangeAndDataSource TO PUBLIC
GO