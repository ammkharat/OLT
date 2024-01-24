IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitLubesGroups')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllWorkPermitLubesGroups
	END
GO

CREATE Procedure [dbo].QueryAllWorkPermitLubesGroups
AS

SELECT wplg.*, pg.SAPImportPriority, pg.SAPPlannerGroup FROM WorkPermitLubesGroup wplg
left outer join SAPImportPriorityWorkPermitLubesGroup pg on pg.WorkPermitLubesGroupId = wplg.Id
where wplg.Deleted = 0
ORDER BY wplg.DisplayOrder
GO

GRANT EXEC ON QueryAllWorkPermitLubesGroups TO PUBLIC
GO