
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitAttributesByPermitRequestMudsId')
	BEGIN
		DROP Procedure [dbo].QueryPermitAttributesByPermitRequestMudsId
	END
GO
    
CREATE Procedure dbo.QueryPermitAttributesByPermitRequestMudsId    
 (    
  @PermitRequestId BIGINT    
 )    
AS    
SELECT attribute.*    
FROM PermitAttribute attribute,    
PermitRequestMudsPermitAttributeAssociation association    
WHERE association.PermitRequestId = @PermitRequestId    
and attribute.Id = association.PermitAttributeId    
order by attribute.Name 

Go


GRANT EXEC ON QueryPermitAttributesByPermitRequestMudsId TO PUBLIC
GO


