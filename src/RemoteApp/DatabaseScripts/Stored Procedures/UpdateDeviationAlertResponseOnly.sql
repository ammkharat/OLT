 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateDeviationAlertResponseOnly')
	BEGIN
		DROP  Procedure  UpdateDeviationAlertResponseOnly
	END

GO


CREATE Procedure [dbo].UpdateDeviationAlertResponseOnly
(
    @Id bigint,
	@ResponseId bigint
)
AS

UPDATE DeviationAlert
SET	
	[DeviationAlertResponseId] = @ResponseId	
WHERE ID = @Id
GO

GRANT EXEC ON UpdateDeviationAlertResponseOnly TO PUBLIC
GO