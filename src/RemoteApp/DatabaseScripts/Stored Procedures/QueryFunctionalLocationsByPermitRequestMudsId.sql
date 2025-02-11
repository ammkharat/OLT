
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByPermitRequestMudsId')
	BEGIN
		DROP Procedure [dbo].QueryFunctionalLocationsByPermitRequestMudsId
	END
GO

CREATE Procedure [dbo].[QueryFunctionalLocationsByPermitRequestMudsId]  
(  
    @PermitRequestMudsId bigint  
)  
AS  
  
SELECT fl.*   
FROM   
 PermitRequestMudsFunctionalLocation prmfl  
 INNER JOIN FunctionalLocation fl ON prmfl.FunctionalLocationId = fl.Id  
WHERE PermitRequestMudsId = @PermitRequestMudsId
GO


GRANT EXEC ON QueryFunctionalLocationsByPermitRequestMudsId TO PUBLIC
GO

