DECLARE @DECIMAL_PLACE_COUNT_NOT_APPLICABLE INT;
SET @DECIMAL_PLACE_COUNT_NOT_APPLICABLE = -1;

SET IDENTITY_INSERT GasTestElementInfo ON;
INSERT INTO [GasTestElementInfo]
(
    Id,
    Name, 
    Standard,
    SiteId,
    OtherLimits,
    DisplayOrder,
    RangedLimit,
    DecimalPlaceCount,
    GasLimitUnitId,
    ColdMaxValue,
    ColdMinValue,
    HotMinValue,
    CSEMaxValue,
    CSEMinValue,
    InertCSEMaxValue,
    InertCSEMinValue
    
)
VALUES
(
    100,                    -- Id
    'Other - User Defined', -- Name
    0,                      -- Standard
    1,                      -- SiteId
    'Sample Limit',         -- OtherLimits
    NULL,                   -- DisplayOrder
    0,                      -- RangedLimit
    @DECIMAL_PLACE_COUNT_NOT_APPLICABLE, -- DecimalPlaceCount
    NULL,       -- GasLimitUnitId,
    NULL, 	-- ColdMaxValue
    NULL, 	-- ColdMinValue
    NULL,	-- HotMinValue
    NULL,	-- CSEMaxValue
    NULL,	-- CSEMinValue
    NULL,	-- InertCSEMaxValue
    NULL	-- InertCSEMinValue

)

SET IDENTITY_INSERT GasTestElementInfo OFF;
GO