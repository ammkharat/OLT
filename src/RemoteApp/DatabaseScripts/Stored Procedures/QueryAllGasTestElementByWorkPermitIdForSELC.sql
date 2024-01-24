IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllGasTestElementByWorkPermitIdForSELC')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllGasTestElementByWorkPermitIdForSELC
	END
GO

CREATE Procedure [dbo].[QueryAllGasTestElementByWorkPermitIdForSELC]
    (
    @WorkPermitId bigint,
	@siteid bigint
    )
AS
    SELECT
        WorkPermitGasTestElementInfoForSELC.*
    FROM
        WorkPermitGasTestElementInfoForSELC, GasTestElementInfo
    WHERE
        WorkPermitGasTestElementInfoForSELC.GasTestElementInfoId = GasTestElementInfo.Id AND
        GasTestElementInfo.Deleted = 0 AND
		GasTestElementInfo.SiteId = @siteid AND
        WorkPermitGasTestElementInfoForSELC.WorkPermitId = @WorkPermitId
GO

GRANT EXEC ON QueryAllGasTestElementByWorkPermitIdForSELC TO PUBLIC
GO