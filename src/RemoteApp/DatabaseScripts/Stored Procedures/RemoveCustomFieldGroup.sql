IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveCustomFieldGroup')
	BEGIN
		DROP  Procedure  RemoveCustomFieldGroup
	END

GO

CREATE Procedure [dbo].[RemoveCustomFieldGroup]
(
    @Id bigint
)
AS

UPDATE CustomFieldGroup
SET Deleted = 1
WHERE Id = @Id

GO
 