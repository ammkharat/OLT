IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormGN75BId')
	BEGIN
		DROP  Procedure dbo.QueryFormApprovalsByFormGN75BId
	END
GO
CREATE Procedure [dbo].[QueryFormApprovalsByFormGN75BId]
(
    @FormGN75BId bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormGN75BApproval approval
WHERE FormGN75BId = @FormGN75BId
ORDER BY approval.DisplayOrder ASC

