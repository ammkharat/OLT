if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTargetDefinitionState]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertTargetDefinitionState]
GO

CREATE Procedure [dbo].[InsertTargetDefinitionState]
    (
    @TargetDefinitionId bigint,
    @ExceedingBoundaries bit, 
	@LastSuccessfulTagAccess datetime
    )
AS

INSERT INTO TargetDefinitionState
(
    [TargetDefinitionId],
    ExceedingBoundaries,
    LastSuccessfulTagAccess
)
VALUES
(
    @TargetDefinitionId,
    @ExceedingBoundaries,
	@LastSuccessfulTagAccess
)
GO