IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogWorkPermitMontrealAssociation')
	BEGIN
		DROP  Procedure InsertLogWorkPermitMontrealAssociation
	END
GO

CREATE Procedure [dbo].InsertLogWorkPermitMontrealAssociation
	(
	@LogId bigint,
	@WorkPermitMontrealId bigint
	)
AS

INSERT INTO 
	[LogWorkPermitMontrealAssociation]
	(	
	[LogId],
	[WorkPermitMontrealId]
	)
VALUES
	(	
	@LogId,
	@WorkPermitMontrealId
	)
	
GRANT EXEC ON InsertLogWorkPermitMontrealAssociation TO PUBLIC
GO