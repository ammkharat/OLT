IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormLubesCsdId')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormLubesCsdId
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormLubesCsdId
(
    @FormLubesCsdId bigint
)
AS

SELECT approval.* 
FROM 
	FormLubesCsdApproval approval
WHERE FormLubesCsdId = @FormLubesCsdId
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormLubesCsdId TO PUBLIC
GO