IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryStandardGasTestElementInfosBySiteId')
    BEGIN
        DROP PROCEDURE [dbo].QueryStandardGasTestElementInfosBySiteId
    END
GO

CREATE Procedure [dbo].QueryStandardGasTestElementInfosBySiteId
(
    @SiteId bigint
)
AS
    SELECT
        *
    FROM
        GasTestElementInfo
    WHERE
        SiteId = @SiteId AND
        Standard = 1 AND
        Deleted = 0
    ORDER BY
        DisplayOrder ASC
GO

GRANT EXEC ON QueryStandardGasTestElementInfosBySiteId TO PUBLIC
GO