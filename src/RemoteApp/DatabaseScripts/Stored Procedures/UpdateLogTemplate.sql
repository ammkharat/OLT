  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateLogTemplate')
	BEGIN
		DROP  Procedure  UpdateLogTemplate
	END

GO

CREATE Procedure [dbo].[UpdateLogTemplate]
	(
	@Id bigint,
	@Name varchar(128),
	@Text varchar(MAX),
	@AppliesToLogs bit,
	@AppliesToSummaryLogs bit,
	@AppliesToDirectives bit,
	@LastModifiedUserId bigint,
	@LastModifiedDateTime datetime
	)
AS
UPDATE    [LogTemplate]
SET       [Name] = @Name,
		  [Text] = @Text,
		  [AppliesToLogs] = @AppliesToLogs,
		  [AppliesToSummaryLogs] = @AppliesToSummaryLogs,
		  [AppliesToDirectives] = @AppliesToDirectives,
		  [LastModifiedUserId] = @LastModifiedUserId,
		  [LastModifiedDateTime] = @LastModifiedDateTime
WHERE     (Id = @Id)
GO

GRANT EXEC ON UpdateLogTemplate TO PUBLIC

GO


  