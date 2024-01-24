IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitEdmontonGroups')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllWorkPermitEdmontonGroups
	END
GO

CREATE Procedure [dbo].QueryAllWorkPermitEdmontonGroups
AS

SELECT wpeg.*, priority.SAPImportPriority
FROM WorkPermitEdmontonGroup wpeg
left outer join SAPImportPriorityWorkPermitEdmontonGroup priority on priority.WorkPermitEdmontonGroupId = wpeg.Id
where wpeg.Deleted = 0
ORDER BY wpeg.DisplayOrder
GO

GRANT EXEC ON QueryAllWorkPermitEdmontonGroups TO PUBLIC
GO