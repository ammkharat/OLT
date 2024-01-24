CREATE TABLE [dbo].[PermitRequestOssaWorkPermitOssaAssociation]
(
PermitRequestId bigint not null,
WorkPermitId bigint not null
)

GO

ALTER TABLE [dbo].[PermitRequestOssaWorkPermitOssaAssociation]
ADD CONSTRAINT FK_PermitRequestOssa_PermitRequestOssaWorkPermitOssaAssociation
FOREIGN KEY(PermitRequestId) REFERENCES PermitRequestOssa(Id);

ALTER TABLE [dbo].[PermitRequestOssaWorkPermitOssaAssociation]
ADD CONSTRAINT FK_WorkPermitOssa_PermitRequestOssaWorkPermitOssaAssociation
FOREIGN KEY(WorkPermitId) REFERENCES WorkPermitOssa(Id);

GO




GO




GO

-- rename table & contraints. wrong spelling.
EXEC sp_RENAME 'PermitRequestMontealWorkPermitMontrealAssociation' , 'PermitRequestMontrealWorkPermitMontrealAssociation', 'OBJECT'

GO

EXEC sp_RENAME 'FK_PermitRequestMontreal_PermitRequestMontealWorkPermitMontrealAssociation', 'FK_PermitRequestMontreal_PermitRequestWorkPermitAssociation', 'OBJECT'
EXEC sp_RENAME 'FK_WorkPermitMontreal_PermitRequestMontealWorkPermitMontrealAssociation', 'FK_WorkPermitMontreal_PermitRequestWorkPermitAssociation', 'OBJECT'

GO





GO

-- Drop the Proc with the wrong name
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestMontealWorkPermitMontrealAssociation')
	BEGIN
		DROP  Procedure  InsertPermitRequestMontealWorkPermitMontrealAssociation
	END

GO

-- Recreate with proper name
-- Stored Proc to Insert an association between a PermitRequest and a WorkPermit. Occurs when a Permit Request is submitted.
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestMontrealWorkPermitMontrealAssociation')
	BEGIN
		DROP  Procedure  InsertPermitRequestMontrealWorkPermitMontrealAssociation
	END

GO

CREATE Procedure [dbo].[InsertPermitRequestMontrealWorkPermitMontrealAssociation]
	(
	@PermitRequestId bigint,
	@WorkPermitId bigint	
	)
AS

INSERT INTO PermitRequestMontrealWorkPermitMontrealAssociation
(
	PermitRequestId, 
	WorkPermitId
)
VALUES
(
	@PermitRequestId, 
	@WorkPermitId
)
GO

GRANT EXEC ON InsertPermitRequestMontrealWorkPermitMontrealAssociation TO PUBLIC
GO


GO

