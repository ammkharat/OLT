IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertGasTestElementInfo')
    BEGIN
        DROP  Procedure  InsertGasTestElementInfo
    END

GO

CREATE Procedure [dbo].[InsertGasTestElementInfo]
(
    @Id bigint OUTPUT,
    @Name VARCHAR(50),
    @SiteId bigint,
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

INSERT INTO [GasTestElementInfo]
(
    [Name],
    [Standard],
    [SiteId],
    [DisplayOrder],
    [ColdMaxValue],
    [ColdMinValue],
    [HotMaxValue],
    [HotMinValue],
    [CSEMaxValue],
    [CSEMinValue],
    [InertCSEMaxValue],
    [InertCSEMinValue],
    [OtherLimits],
    [GasLimitUnitId],
    [RangedLimit],
    [DecimalPlaceCount]
)
VALUES
(
    @Name,
    0,
    @SiteId,
    NULL,
    @ColdMaxValue,
    @ColdMinValue,
    @HotMaxValue,
    @HotMinValue,
    @CSEMaxValue,
    @CSEMinValue,
    @InertCSEMaxValue,
    @InertCSEMinValue,
    @OtherLimits,
    @GasLimitUnitId,
    @RangedLimit,
    @DecimalPlaceCount
)

SET @Id= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertGasTestElementInfo] TO PUBLIC
GO