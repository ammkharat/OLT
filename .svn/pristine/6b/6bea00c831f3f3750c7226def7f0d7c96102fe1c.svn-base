IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsBySummaryLogId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsBySummaryLogId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsBySummaryLogId
(
    @SummaryLogId bigint
)
AS

SELECT fl.* 
FROM 
	SummaryLogFunctionalLocation lfl
	INNER JOIN FunctionalLocation fl ON lfl.FunctionalLocationId = fl.Id
WHERE SummaryLogId = @SummaryLogId
GO

GRANT EXEC ON QueryFunctionalLocationsBySummaryLogId TO PUBLIC
GO