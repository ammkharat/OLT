if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertActionItemFunctionalLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertActionItemFunctionalLocation]
GO

CREATE Procedure [dbo].[InsertActionItemFunctionalLocation]
    (
	@ActionItemId bigint,
	@FunctionalLocationId bigint
    )
AS

INSERT INTO ActionItemFunctionalLocation
(
    ActionItemId,
	FunctionalLocationId
)
VALUES
(
    @ActionItemId,
	@FunctionalLocationId
)

GO 
GRANT EXEC ON InsertActionItemFunctionalLocation TO PUBLIC
GO  