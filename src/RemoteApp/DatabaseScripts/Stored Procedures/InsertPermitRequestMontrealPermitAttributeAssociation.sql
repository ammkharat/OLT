IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestMontrealPermitAttributeAssociation')
	BEGIN
		DROP  Procedure  InsertPermitRequestMontrealPermitAttributeAssociation
	END

GO

CREATE Procedure [dbo].[InsertPermitRequestMontrealPermitAttributeAssociation]
	(
	@PermitRequestId bigint,
	@PermitAttributeId bigint	
	)
AS

INSERT INTO PermitRequestMontrealPermitAttributeAssociation
(
	PermitRequestId, 
	PermitAttributeId
)
VALUES
(
	@PermitRequestId, 
	@PermitAttributeId
)
GO

GRANT EXEC ON InsertPermitRequestMontrealPermitAttributeAssociation TO PUBLIC
GO


 