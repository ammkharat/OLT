IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByWorkPermitMontrealId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByWorkPermitMontrealId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByWorkPermitMontrealId
(
    @WorkPermitMontrealId bigint
)
AS

SELECT fl.* 
FROM 
	WorkPermitMontrealFunctionalLocation wpmfl
	INNER JOIN FunctionalLocation fl ON wpmfl.FunctionalLocationId = fl.Id
WHERE WorkPermitMontrealId = @WorkPermitMontrealId
GO

GRANT EXEC ON QueryFunctionalLocationsByWorkPermitMontrealId TO PUBLIC
GO