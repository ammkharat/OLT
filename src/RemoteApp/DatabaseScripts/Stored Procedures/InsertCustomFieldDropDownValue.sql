IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertCustomFieldDropDownValue')
	BEGIN
		DROP  Procedure  InsertCustomFieldDropDownValue
	END

GO

CREATE Procedure [dbo].[InsertCustomFieldDropDownValue]
(
    @CustomFieldId bigint,
    @Value varchar(100),
	@DisplayOrder int
)
AS

INSERT INTO [CustomFieldDropDownValue]
(
	[CustomFieldId],
    [Value],
	[DisplayOrder]
)
VALUES
(
	@CustomFieldId,
    @Value,
	@DisplayOrder
)

GRANT EXEC ON InsertCustomFieldDropDownValue TO PUBLIC
GO
 