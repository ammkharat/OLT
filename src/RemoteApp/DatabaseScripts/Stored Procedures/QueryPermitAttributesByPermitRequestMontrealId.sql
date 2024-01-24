IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitAttributesByPermitRequestMontrealId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitAttributesByPermitRequestMontrealId
	END
GO

CREATE Procedure dbo.QueryPermitAttributesByPermitRequestMontrealId
	(
		@PermitRequestId BIGINT
	)
AS
SELECT attribute.*
FROM PermitAttribute attribute,
PermitRequestMontrealPermitAttributeAssociation association
WHERE association.PermitRequestId = @PermitRequestId
and attribute.Id = association.PermitAttributeId
order by attribute.Name
GO

GRANT EXEC ON QueryPermitAttributesByPermitRequestMontrealId TO PUBLIC
GO
