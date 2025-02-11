
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitMudsGroups')
	BEGIN
		DROP Procedure [dbo].QueryAllWorkPermitMudsGroups
	END
GO

CREATE Procedure [dbo].[QueryAllWorkPermitMudsGroups]
AS

SELECT g.*
FROM WorkPermitMudsGroup g
where g.Deleted = 0
ORDER BY g.DisplayOrder
GO


GRANT EXEC ON QueryAllWorkPermitMudsGroups TO PUBLIC
GO

