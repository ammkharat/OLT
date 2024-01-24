if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormApprovalsByFormGN75BSarniaId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormApprovalsByFormGN75BSarniaIdId]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[QueryFormApprovalsByFormGN75BSarniaId]
(
    @FormGN75BId bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormGN75BSarniaApproval approval
WHERE FormGN75BId = @FormGN75BId
ORDER BY approval.DisplayOrder ASC

