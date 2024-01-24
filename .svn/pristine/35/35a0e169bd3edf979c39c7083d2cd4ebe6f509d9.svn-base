IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogTemplateWorkAssignment')
	BEGIN
		DROP  Procedure  InsertLogTemplateWorkAssignment
	END

GO

CREATE Procedure [dbo].[InsertLogTemplateWorkAssignment]
(
    @LogTemplateId bigint,
    @WorkAssignmentId bigint
)
AS

INSERT INTO [LogTemplateWorkAssignment]
(
    [LogTemplateId],
    [WorkAssignmentId]
)
VALUES
(
    @LogTemplateId,
    @WorkAssignmentId
)

GO
  