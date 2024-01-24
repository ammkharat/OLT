IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePermitRequestEdmontonPermitAttributeAssociation')
	BEGIN
		DROP  Procedure  DeletePermitRequestEdmontonPermitAttributeAssociation
	END

GO

CREATE Procedure [dbo].DeletePermitRequestEdmontonPermitAttributeAssociation
	(
		@PermitRequestId bigint
	)
AS

DELETE FROM PermitRequestEdmontonPermitAttributeAssociation 
WHERE PermitRequestEdmontonId = @PermitRequestId
GO


GRANT EXEC ON DeletePermitRequestEdmontonPermitAttributeAssociation TO PUBLIC

GO

