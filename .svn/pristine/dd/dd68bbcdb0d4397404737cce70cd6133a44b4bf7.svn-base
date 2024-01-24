 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateGasTestElementInfo')
    BEGIN
        DROP Procedure UpdateGasTestElementInfo
    END
GO

CREATE Procedure [dbo].UpdateGasTestElementInfo
(
    @Id bigint,
    @Name VARCHAR(50),
    @Standard BIT,
    @SiteId bigint,
    @DisplayOrder FLOAT = NULL,
    @ColdMaxValue FLOAT = NULL,
    @ColdMinValue FLOAT = NULL,
    @HotMaxValue FLOAT = NULL,
    @HotMinValue FLOAT = NULL,
    @CSEMaxValue FLOAT = NULL,
    @CSEMinValue FLOAT = NULL,
    @InertCSEMaxValue FLOAT = NULL,
    @InertCSEMinValue FLOAT = NULL,
    @OtherLimits VARCHAR(50) = NULL,
    @GasLimitUnitId bigint = NULL,
    @RangedLimit BIT,
    @DecimalPlaceCount INT
)
AS

UPDATE
    GasTestElementInfo
SET
    Name = @Name,
    Standard = @Standard,
    SiteId = @SiteId,
    DisplayOrder = @DisplayOrder,
    ColdMaxValue = @ColdMaxValue,
    ColdMinValue = @ColdMinValue,
    HotMaxValue = @HotMaxValue,
    HotMinValue = @HotMinValue,
    CSEMaxValue = @CSEMaxValue,
    CSEMinValue = @CSEMinValue,
    InertCSEMaxValue = @InertCSEMaxValue,
    InertCSEMinValue = @InertCSEMinValue,
    OtherLimits = @OtherLimits,
    GasLimitUnitId = @GasLimitUnitId,
    RangedLimit = @RangedLimit,
    DecimalPlaceCount = @DecimalPlaceCount
WHERE
    ID = @Id

GO

GRANT EXEC ON UpdateGasTestElementInfo TO PUBLIC

GO 