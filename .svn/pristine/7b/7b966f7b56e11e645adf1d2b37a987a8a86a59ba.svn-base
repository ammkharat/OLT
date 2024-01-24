IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormLubesAlarmDisableId')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormLubesAlarmDisableId
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormLubesAlarmDisableId
(
    @FormLubesAlarmDisableId bigint
)
AS

SELECT approval.* 
FROM 
	FormLubesAlarmDisableApproval approval
WHERE FormLubesAlarmDisableId = @FormLubesAlarmDisableId
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormLubesAlarmDisableId TO PUBLIC
GO