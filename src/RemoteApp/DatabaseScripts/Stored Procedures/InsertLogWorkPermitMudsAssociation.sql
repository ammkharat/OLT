
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogWorkPermitMudsAssociation')
	BEGIN
		DROP Procedure [dbo].InsertLogWorkPermitMudsAssociation
	END
GO

CREATE Procedure [dbo].[InsertLogWorkPermitMudsAssociation]
	(
	@LogId bigint,
	@WorkPermitMudsId bigint
	)
AS

INSERT INTO 
	[LogWorkPermitMudsAssociation]
	(	
	[LogId],
	[WorkPermitMudsId]
	)
VALUES
	(	
	@LogId,
	@WorkPermitMudsId
	)
	
GRANT EXEC ON InsertLogWorkPermitMudsAssociation TO PUBLIC
GO
