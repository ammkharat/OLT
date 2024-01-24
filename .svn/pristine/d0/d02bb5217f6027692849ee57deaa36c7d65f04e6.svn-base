IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryStandardGasTestElementInfoDTOsBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryStandardGasTestElementInfoDTOsBySiteId
	END
GO

CREATE Procedure [dbo].QueryStandardGasTestElementInfoDTOsBySiteId
(
    @SiteId bigint
)
AS
    SELECT
        Id,
        Name,
        ColdMaxValue,
        ColdMinValue,
        HotMaxValue,
        HotMinValue,
        CSEMaxValue,
        CSEMinValue,
        InertCSEMaxValue,
        InertCSEMinValue,
        GasLimitUnitId,
        RangedLimit,
        DecimalPlaceCount
    FROM
        GasTestElementInfo
    WHERE
        SiteId = @SiteId AND
        Standard = 1 AND
		Deleted = 0
    ORDER BY
        DisplayOrder ASC
GO

GRANT EXEC ON QueryStandardGasTestElementInfoDTOsBySiteId TO PUBLIC
GO