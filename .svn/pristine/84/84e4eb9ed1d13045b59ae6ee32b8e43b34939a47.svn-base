IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogWorkPermitEdmontonAssociation')
	BEGIN
		DROP  Procedure InsertLogWorkPermitEdmontonAssociation
	END
GO

CREATE Procedure [dbo].InsertLogWorkPermitEdmontonAssociation
	(
	@LogId bigint,
	@WorkPermitEdmontonId bigint
	)
AS

INSERT INTO 
	[LogWorkPermitEdmontonAssociation]
	(	
	[LogId],
	[WorkPermitEdmontonId]
	)
VALUES
	(	
	@LogId,
	@WorkPermitEdmontonId
	)
	
GRANT EXEC ON InsertLogWorkPermitEdmontonAssociation TO PUBLIC
GO