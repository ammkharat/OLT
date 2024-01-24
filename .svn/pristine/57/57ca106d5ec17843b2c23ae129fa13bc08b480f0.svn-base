IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertCustomFieldGroupWorkAssignment')
	BEGIN
		DROP  Procedure  InsertCustomFieldGroupWorkAssignment
	END

GO

CREATE Procedure [dbo].[InsertCustomFieldGroupWorkAssignment]
(
    @CustomFieldGroupId bigint,
	@WorkAssignmentId bigint
)
AS

INSERT INTO [CustomFieldGroupWorkAssignment]
(
	[CustomFieldGroupId],
	[WorkAssignmentId]
)
VALUES
(
	@CustomFieldGroupId,
    @WorkAssignmentId
)


GO
 