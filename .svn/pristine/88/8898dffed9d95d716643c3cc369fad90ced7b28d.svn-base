if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertRestrictionLocationWorkAssignment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertRestrictionLocationWorkAssignment]
GO

CREATE Procedure [dbo].[InsertRestrictionLocationWorkAssignment]
    (
    @RestrictionLocationId bigint,
    @WorkAssignmentId bigint
    )
AS

INSERT INTO RestrictionLocationWorkAssignment
(
    [RestrictionLocationId],
    WorkAssignmentId
)
VALUES
(
    @RestrictionLocationId,
    @WorkAssignmentId
)
GO