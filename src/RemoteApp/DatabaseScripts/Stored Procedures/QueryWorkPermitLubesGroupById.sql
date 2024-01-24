IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitLubesGroupById')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitLubesGroupById
	END
GO

CREATE Procedure [dbo].QueryWorkPermitLubesGroupById(@Id int)
AS

SELECT wplg.*, pg.SAPImportPriority, pg.SAPPlannerGroup FROM WorkPermitLubesGroup wplg
left outer join SAPImportPriorityWorkPermitLubesGroup pg on pg.WorkPermitLubesGroupId = wplg.Id
WHERE wplg.Id = @Id
GO

GRANT EXEC ON QueryWorkPermitLubesGroupById TO PUBLIC
GO