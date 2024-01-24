IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogWorkPermitLubesAssociation')
	BEGIN
		DROP  Procedure InsertLogWorkPermitLubesAssociation
	END
GO

CREATE Procedure [dbo].InsertLogWorkPermitLubesAssociation
	(
	@LogId bigint,
	@WorkPermitLubesId bigint
	)
AS

INSERT INTO 
	[LogWorkPermitLubesAssociation]
	(	
	[LogId],
	[WorkPermitLubesId]
	)
VALUES
	(	
	@LogId,
	@WorkPermitLubesId
	)
	
GRANT EXEC ON InsertLogWorkPermitLubesAssociation TO PUBLIC
GO