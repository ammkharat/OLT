IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE Id = OBJECT_ID(N'[dbo].[InsertFunctionalLocationOperationalMode]') AND OBJECTPROPERTY(Id, N'IsProcedure') = 1 )
DROP PROCEDURE [dbo].[InsertFunctionalLocationOperationalMode]
GO

CREATE PROCEDURE [dbo].[InsertFunctionalLocationOperationalMode]
(
    @UnitId BIGINT,
    @OperationalModeId BIGINT,
    @AvailabilityReasonId BIGINT,
    @LastModifiedDateTime DATETIME
)
AS
INSERT INTO [FunctionalLocationOperationalMode]
(
    UnitId,
    OperationalModeId,
    AvailabilityReasonId,
    LastModifiedDateTime
)
VALUES
(
    @UnitId,
    @OperationalModeId,
    @AvailabilityReasonId,
    @LastModifiedDateTime
)

GRANT EXEC ON [InsertFunctionalLocationOperationalMode] TO PUBLIC
GO

