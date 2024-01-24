IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertActionItemCustomFieldGroup')
    BEGIN
        DROP PROCEDURE [dbo].InsertActionItemCustomFieldGroup
    END
GO

CREATE Procedure [dbo].[InsertActionItemCustomFieldGroup]
    (
    @ActionItemId bigint,
	@CustomFieldGroupId bigint
    )
AS

INSERT INTO ActionItemCustomFieldGroup (ActionItemId, CustomFieldGroupId)
values (@ActionItemId, @CustomFieldGroupId)

