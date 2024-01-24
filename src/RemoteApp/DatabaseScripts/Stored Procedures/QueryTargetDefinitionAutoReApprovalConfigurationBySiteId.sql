IF EXISTS ( SELECT * FROM sysobjects WHERE type = 'P' AND Name = 'QueryTargetDefinitionAutoReApprovalConfigurationBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionAutoReApprovalConfigurationBySiteId;
	END
GO

CREATE PROCEDURE [dbo].QueryTargetDefinitionAutoReApprovalConfigurationBySiteId
(
    @SiteId BIGINT
)
AS

SELECT
	*
FROM
	TargetDefinitionAutoReApprovalConfiguration
WHERE
	SiteId = @SiteId
GO

GRANT EXEC ON QueryTargetDefinitionAutoReApprovalConfigurationBySiteId TO PUBLIC
GO 