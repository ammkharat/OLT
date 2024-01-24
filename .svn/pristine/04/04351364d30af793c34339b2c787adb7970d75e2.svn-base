  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateGasTestElementInfoDTO')
    BEGIN
        DROP Procedure UpdateGasTestElementInfoDTO
    END
GO

CREATE Procedure [dbo].UpdateGasTestElementInfoDTO
(
    @Id bigint,
    @ColdMaxValue FLOAT = NULL,
    @ColdMinValue FLOAT = NULL,
    @HotMaxValue FLOAT = NULL,
    @HotMinValue FLOAT = NULL,
    @CSEMaxValue FLOAT = NULL,
    @CSEMinValue FLOAT = NULL,
    @InertCSEMaxValue FLOAT = NULL,
    @InertCSEMinValue FLOAT = NULL,
    @GasLimitUnitId bigint = NULL
)
AS

UPDATE
    GasTestElementInfo
SET
    ColdMaxValue = @ColdMaxValue,
    ColdMinValue = @ColdMinValue,
    HotMaxValue = @HotMaxValue,
    HotMinValue = @HotMinValue,
    CSEMaxValue = @CSEMaxValue,
    CSEMinValue = @CSEMinValue,
    InertCSEMaxValue = @InertCSEMaxValue,
    InertCSEMinValue = @InertCSEMinValue,
    GasLimitUnitId = @GasLimitUnitId
WHERE
    ID = @Id

GO

GRANT EXEC ON UpdateGasTestElementInfoDTO TO PUBLIC

GO 