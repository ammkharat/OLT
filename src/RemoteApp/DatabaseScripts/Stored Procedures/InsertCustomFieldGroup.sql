IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertCustomFieldGroup')
	BEGIN
		DROP  Procedure  InsertCustomFieldGroup
	END

GO

CREATE Procedure [dbo].[InsertCustomFieldGroup]
(
    @Id bigint Output,
    @Name varchar(100),
	@AppliesToLogs bit,
	@AppliesToSummaryLogs bit,
	@AppliesToDailyDirectives bit,
	@AppliesToActionItems bit,
	@OriginCustomFieldGroupId bigint = NULL
	
)
AS

INSERT INTO [CustomFieldGroup]
(
    [Name],
	AppliesToLogs,
	AppliesToSummaryLogs,
	AppliesToDailyDirectives,
	AppliesToActionItems,
	OriginCustomFieldGroupId,
	Deleted
)
VALUES
(
    @Name,
	@AppliesToLogs,
	@AppliesToSummaryLogs,
	@AppliesToDailyDirectives,
	@AppliesToActionItems,
	@OriginCustomFieldGroupId,
	0
)

SET @Id = SCOPE_IDENTITY() 

if (@OriginCustomFieldGroupId is null)
begin
	update CustomFieldGroup set OriginCustomFieldGroupId = @Id where Id = @Id
end


GO
 