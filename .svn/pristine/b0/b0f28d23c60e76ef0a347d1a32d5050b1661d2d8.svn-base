IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitAttributesByWorkPermitMontrealId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitAttributesByWorkPermitMontrealId
	END
GO

CREATE Procedure dbo.QueryPermitAttributesByWorkPermitMontrealId
	(
		@WorkPermitMontrealId BIGINT
	)
AS
SELECT attribute.*
FROM PermitAttribute attribute,
WorkPermitMontrealPermitAttributeAssociation association
WHERE association.WorkPermitMontrealId = @WorkPermitMontrealId
and attribute.Id = association.PermitAttributeId
order by attribute.Name
GO

GRANT EXEC ON QueryPermitAttributesByWorkPermitMontrealId TO PUBLIC
GO
