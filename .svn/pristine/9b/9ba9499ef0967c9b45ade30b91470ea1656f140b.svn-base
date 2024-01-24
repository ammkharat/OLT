IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonGroupById')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitEdmontonGroupById
	END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonGroupById
	(
		@Id int
	)
AS

SELECT wpeg.*, priority.SAPImportPriority
FROM WorkPermitEdmontonGroup wpeg
left outer join SAPImportPriorityWorkPermitEdmontonGroup priority on priority.WorkPermitEdmontonGroupId = wpeg.Id
WHERE wpeg.Id = @Id
GO

GRANT EXEC ON QueryWorkPermitEdmontonGroupById TO PUBLIC
GO