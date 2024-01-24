IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormMontrealCsdId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormMontrealCsdId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormMontrealCsdId
(
    @FormMontrealCsdId bigint
)
AS

SELECT fl.* 
FROM 
	FormMontrealCsdFunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormMontrealCsdId = @FormMontrealCsdId
GO

GRANT EXEC ON QueryFunctionalLocationsByFormMontrealCsdId TO PUBLIC
GO