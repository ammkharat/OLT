IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitMontrealGroups')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllWorkPermitMontrealGroups
	END
GO

CREATE Procedure [dbo].QueryAllWorkPermitMontrealGroups
AS

SELECT g.*
FROM WorkPermitMontrealGroup g
where g.Deleted = 0
ORDER BY g.DisplayOrder
GO

GRANT EXEC ON QueryAllWorkPermitMontrealGroups TO PUBLIC
GO