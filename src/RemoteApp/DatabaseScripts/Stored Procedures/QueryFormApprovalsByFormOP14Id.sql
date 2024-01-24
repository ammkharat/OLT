IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormOP14Id')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormOP14Id
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormOP14Id
(
    @FormOP14Id bigint
)
AS

SELECT approval.* 
FROM 
	FormOP14Approval approval
WHERE FormOP14Id = @FormOP14Id
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormOP14Id TO PUBLIC
GO