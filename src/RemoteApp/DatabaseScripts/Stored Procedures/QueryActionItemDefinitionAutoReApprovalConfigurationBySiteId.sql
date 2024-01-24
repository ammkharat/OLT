IF EXISTS ( SELECT * FROM sysobjects WHERE type = 'P' AND NAME = 'QueryActionItemDefinitionAutoReApprovalConfigurationBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemDefinitionAutoReApprovalConfigurationBySiteId
	END
GO

CREATE PROCEDURE dbo.QueryActionItemDefinitionAutoReApprovalConfigurationBySiteId
(
    @SiteId BIGINT
)
AS

SELECT
	*
FROM
	ActionItemDefinitionAutoReApprovalConfiguration
WHERE
	SiteId = @SiteId
GO

GRANT EXEC ON QueryActionItemDefinitionAutoReApprovalConfigurationBySiteId TO PUBLIC
GO