if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormApprovalsByFormGenericTemplateId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormApprovalsByFormGenericTemplateId]
GO


CREATE Procedure [dbo].[QueryFormApprovalsByFormGenericTemplateId]
(
    @FormGenericTemplateId bigint
)
AS

SELECT approval.* 
FROM 
	FormGenericTemplateApproval approval
WHERE FormGenericTemplateId = @FormGenericTemplateId
ORDER BY approval.DisplayOrder ASC


GO

GRANT EXEC ON QueryFormApprovalsByFormGenericTemplateId TO PUBLIC
GO
