
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLogDefinitionFunctionalLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLogDefinitionFunctionalLocation]
GO

CREATE Procedure [dbo].[InsertLogDefinitionFunctionalLocation]
    (
	@LogDefinitionId bigint,
	@FunctionalLocationId bigint
    )
AS

INSERT INTO LogDefinitionFunctionalLocation
(
    LogDefinitionId,
	FunctionalLocationId
)
VALUES
(
    @LogDefinitionId,
	@FunctionalLocationId
)

GO 
GRANT EXEC ON [InsertLogDefinitionFunctionalLocation] TO PUBLIC
GO    