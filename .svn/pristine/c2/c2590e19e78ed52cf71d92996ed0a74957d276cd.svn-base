IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormOilsandsTrainingId')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormOilsandsTrainingId
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormOilsandsTrainingId
(
    @FormOilsandsTrainingId bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormOilsandsTrainingApproval approval
WHERE FormOilsandsTrainingId = @FormOilsandsTrainingId
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormOilsandsTrainingId TO PUBLIC
GO