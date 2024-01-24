IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePermitRequestMontrealPermitAttributeAssociation')
	BEGIN
		DROP  Procedure  DeletePermitRequestMontrealPermitAttributeAssociation
	END

GO

CREATE Procedure [dbo].DeletePermitRequestMontrealPermitAttributeAssociation
	(
		@PermitRequestId bigint
	)
AS

DELETE FROM PermitRequestMontrealPermitAttributeAssociation 
WHERE PermitRequestId = @PermitRequestId
GO


GRANT EXEC ON DeletePermitRequestMontrealPermitAttributeAssociation TO PUBLIC

GO

