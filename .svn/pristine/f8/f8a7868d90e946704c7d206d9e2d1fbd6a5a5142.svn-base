if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTargetAlertResponse]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertTargetAlertResponse]
GO


CREATE Procedure [dbo].[InsertTargetAlertResponse]
    (
    @Id bigint Output,
    @TargetAlertId bigint,
    @CommentId bigint,
    @CreatedShiftPatternId bigint,
    @TargetGapReasonId bigint = NULL,
    @ResponsibleFunctionalLocationId bigint = NULL
    )
AS

INSERT INTO TargetAlertResponse
(
    [TargetAlertId],
    [CommentId],
    [TargetGapReasonId],
    [ResponsibleFunctionalLocationId],
    [CreatedShiftPatternId]
)
VALUES
(
    @TargetAlertId,
    @CommentId,
    @TargetGapReasonId,
    @ResponsibleFunctionalLocationId,
    @CreatedShiftPatternId
)
SET @Id= SCOPE_IDENTITY() 
GO 

GRANT EXEC ON InsertTargetAlertResponse TO PUBLIC
GO   