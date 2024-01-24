IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogTemplate')
	BEGIN
		DROP  Procedure  InsertLogTemplate
	END
GO

CREATE Procedure [dbo].[InsertLogTemplate]
(
    @Id bigint Output,
    @Name varchar(128),
	@Text varchar(MAX),
	@AppliesToLogs bit,
	@AppliesToSummaryLogs bit,
	@AppliesToDirectives bit,
	@LastModifiedUserId bigint,
	@LastModifiedDateTime datetime,
	@CreatedUserId bigint,
	@CreatedDateTime datetime	
)
AS

INSERT INTO [LogTemplate]
(	
    [Name], 
	[Text],
	[AppliesToLogs],
	[AppliesToSummaryLogs],
	[AppliesToDirectives],
	[LastModifiedUserId],
	[LastModifiedDateTime],
	[CreatedUserId],
	[CreatedDateTime]	
)
VALUES
(
    @Name,
	@Text,
	@AppliesToLogs,
	@AppliesToSummaryLogs,
	@AppliesToDirectives,
	@LastModifiedUserId,
	@LastModifiedDateTime,
	@CreatedUserId,
	@CreatedDateTime
)

SET @Id = SCOPE_IDENTITY() 

GO
 