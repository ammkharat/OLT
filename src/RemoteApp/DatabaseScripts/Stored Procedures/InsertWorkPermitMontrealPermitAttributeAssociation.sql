IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMontrealPermitAttributeAssociation')
	BEGIN
		DROP  Procedure  InsertWorkPermitMontrealPermitAttributeAssociation
	END

GO

CREATE Procedure [dbo].[InsertWorkPermitMontrealPermitAttributeAssociation]
	(
	@WorkPermitMontrealId bigint,
	@PermitAttributeId bigint	
	)
AS

INSERT INTO WorkPermitMontrealPermitAttributeAssociation
(
	WorkPermitMontrealId, 
	PermitAttributeId
)
VALUES
(
	@WorkPermitMontrealId, 
	@PermitAttributeId
)
GO

GRANT EXEC ON InsertWorkPermitMontrealPermitAttributeAssociation TO PUBLIC
GO


 