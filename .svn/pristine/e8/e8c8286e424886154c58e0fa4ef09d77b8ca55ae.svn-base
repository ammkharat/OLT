IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogTargetAlertAssociation')
	BEGIN
		DROP  Procedure  InsertLogTargetAlertAssociation
	END

GO

CREATE Procedure [dbo].[InsertLogTargetAlertAssociation]
	(
	@LogId bigint,
	@TargetAlertId bigint
	)
AS

INSERT INTO 
	[LogTargetAlertAssociation]
	(	
	[LogId],
	[TargetAlertId]
	)
VALUES
	(
	@LogId,
	@TargetAlertId
	)

GRANT EXEC ON [InsertLogTargetAlertAssociation] TO PUBLIC
GO