 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateLogGuideline')
	BEGIN
		DROP  Procedure  UpdateLogGuideline
	END

GO

CREATE Procedure [dbo].[UpdateLogGuideline]
	(
	@Id bigint,
	@FunctionalLocationId bigint,    
    @Text varchar(MAX) = NULL
	)
AS

UPDATE
    [LogGuideline]
SET
    FunctionalLocationId = @FunctionalLocationId,
	Text = @Text
WHERE
(
    Id = @Id
)
GO


GRANT EXEC ON UpdateLogGuideline TO PUBLIC

GO


 