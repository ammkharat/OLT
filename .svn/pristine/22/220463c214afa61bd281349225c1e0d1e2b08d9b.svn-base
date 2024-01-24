IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByPermitRequestMontrealId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByPermitRequestMontrealId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByPermitRequestMontrealId
(
    @PermitRequestMontrealId bigint
)
AS

SELECT fl.* 
FROM 
	PermitRequestMontrealFunctionalLocation prmfl
	INNER JOIN FunctionalLocation fl ON prmfl.FunctionalLocationId = fl.Id
WHERE PermitRequestMontrealId = @PermitRequestMontrealId
GO

GRANT EXEC ON QueryFunctionalLocationsByPermitRequestMontrealId TO PUBLIC
GO