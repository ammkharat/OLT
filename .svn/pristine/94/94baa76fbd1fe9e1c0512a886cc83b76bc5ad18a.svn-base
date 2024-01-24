IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllGasTestElementByWorkPermitId')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllGasTestElementByWorkPermitId
	END
GO

CREATE Procedure [dbo].[QueryAllGasTestElementByWorkPermitId]
    (
    @WorkPermitId bigint,
	@siteid bigint
    )
AS
    SELECT
        WorkPermitGasTestElementInfo.*
    FROM
        WorkPermitGasTestElementInfo, GasTestElementInfo
    WHERE
        WorkPermitGasTestElementInfo.GasTestElementInfoId = GasTestElementInfo.Id AND
        GasTestElementInfo.Deleted = 0 AND
		GasTestElementInfo.SiteId = @siteid AND
        WorkPermitGasTestElementInfo.WorkPermitId = @WorkPermitId
GO

GRANT EXEC ON QueryAllGasTestElementByWorkPermitId TO PUBLIC
GO