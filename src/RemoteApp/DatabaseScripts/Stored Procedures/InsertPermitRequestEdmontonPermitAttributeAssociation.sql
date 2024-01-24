IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestEdmontonPermitAttributeAssociation')
	BEGIN
		DROP  Procedure  InsertPermitRequestEdmontonPermitAttributeAssociation
	END

GO

CREATE Procedure [dbo].[InsertPermitRequestEdmontonPermitAttributeAssociation]
	(
	@PermitRequestId bigint,
	@PermitAttributeId bigint	
	)
AS

INSERT INTO PermitRequestEdmontonPermitAttributeAssociation
(
	PermitRequestEdmontonId, 
	PermitAttributeId
)
VALUES
(
	@PermitRequestId, 
	@PermitAttributeId
)
GO

GRANT EXEC ON InsertPermitRequestEdmontonPermitAttributeAssociation TO PUBLIC
GO


 