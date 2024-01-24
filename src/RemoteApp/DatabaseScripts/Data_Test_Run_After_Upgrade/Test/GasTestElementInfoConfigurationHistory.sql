DECLARE @SARNIA_ID BIGINT;
SET @SARNIA_ID = 1;

DECLARE @SYSTEM_USER_ID BIGINT;
SET @SYSTEM_USER_ID = -1;

INSERT INTO [GasTestElementInfoConfigurationHistory]
(
    [Name],
    [SiteId],
    [DisplayOrder],
    [GasLimitUnitId],
    [RangedLimit],
    [ColdMaxValue],
    [ColdMinValue],
    [HotMaxValue],
    [HotMinValue],
    [CSEMaxValue],
    [CSEMinValue],
    [InertCSEMaxValue],
    [InertCSEMinValue],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [DecimalPlaceCount] 
)
SELECT
    GasTestElementInfo.[Name],
    GasTestElementInfo.[SiteId],
    GasTestElementInfo.[DisplayOrder],
    GasTestElementInfo.[GasLimitUnitId],
    GasTestElementInfo.[RangedLimit],
    GasTestElementInfo.[ColdMaxValue],
    GasTestElementInfo.[ColdMinValue],
    GasTestElementInfo.[HotMaxValue],
    GasTestElementInfo.[HotMinValue],
    GasTestElementInfo.[CSEMaxValue],
    GasTestElementInfo.[CSEMinValue],
    GasTestElementInfo.[InertCSEMaxValue],
    GasTestElementInfo.[InertCSEMinValue],
    @SYSTEM_USER_ID,
    GETDATE(),
    GasTestElementInfo.[DecimalPlaceCount]
FROM
    GasTestElementInfo
WHERE
    Standard = 1 AND
    SiteId = @SARNIA_ID
GO
