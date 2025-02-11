
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByWorkPermitMudsId')
	BEGIN
		DROP Procedure [dbo].QueryFunctionalLocationsByWorkPermitMudsId
	END
GO

CREATE Procedure [dbo].[QueryFunctionalLocationsByWorkPermitMudsId]
(
    @WorkPermitMudsId bigint
)
AS

SELECT fl.* 
FROM 
	WorkPermitMudsFunctionalLocation wpmfl
	INNER JOIN FunctionalLocation fl ON wpmfl.FunctionalLocationId = fl.Id
WHERE WorkPermitMudsId = @WorkPermitMudsId
GO

GRANT EXEC ON QueryFunctionalLocationsByWorkPermitMudsId TO PUBLIC
GO

