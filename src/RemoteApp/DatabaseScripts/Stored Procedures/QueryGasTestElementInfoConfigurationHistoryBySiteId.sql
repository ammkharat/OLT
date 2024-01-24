IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryGasTestElementInfoConfigurationHistoryBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryGasTestElementInfoConfigurationHistoryBySiteId
	END

GO

CREATE Procedure [dbo].QueryGasTestElementInfoConfigurationHistoryBySiteId
(
	@SiteId bigint
)
AS
	SELECT * FROM GasTestElementInfoConfigurationHistory WHERE SiteId = 1
	ORDER BY LastModifiedDateTime ASC, [Name] ASC
GO

GRANT EXEC ON [QueryGasTestElementInfoConfigurationHistoryBySiteId] TO PUBLIC
GO