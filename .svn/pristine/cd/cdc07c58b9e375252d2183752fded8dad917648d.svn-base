if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLogFunctionalLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLogFunctionalLocation]
GO

CREATE Procedure [dbo].[InsertLogFunctionalLocation]
    (
	@LogId bigint,
	@FunctionalLocationId bigint
    )
AS

INSERT INTO LogFunctionalLocation
(
    LogId,
	FunctionalLocationId
)
VALUES
(
    @LogId,
	@FunctionalLocationId
)

GO 
GRANT EXEC ON [InsertLogFunctionalLocation] TO PUBLIC
GO   