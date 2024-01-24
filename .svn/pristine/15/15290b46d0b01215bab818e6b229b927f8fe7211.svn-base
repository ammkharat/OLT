 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateDeviationAlertCommentField')
	BEGIN
		DROP  Procedure  UpdateDeviationAlertCommentField
	END

GO


CREATE Procedure [dbo].UpdateDeviationAlertCommentField
(
    @Id bigint,
	@Comments varchar(2048) = NULL
)
AS

UPDATE DeviationAlert
SET	
	[Comments] = @Comments	
WHERE ID = @Id
GO

GRANT EXEC ON UpdateDeviationAlertCommentField TO PUBLIC
GO