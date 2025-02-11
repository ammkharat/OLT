
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitMudsTemplatesNotDeleted')
	BEGIN
		DROP Procedure [dbo].QueryAllWorkPermitMudsTemplatesNotDeleted
	END
GO

-- Get all WorkPermitMudsTemplates that have not been Deleted  
CREATE Procedure [dbo].[QueryAllWorkPermitMudsTemplatesNotDeleted]  
AS  
SELECT * FROM WorkPermitMudsTemplate  
WHERE Deleted = 0;
GO

GRANT EXEC ON QueryAllWorkPermitMudsTemplatesNotDeleted TO PUBLIC
GO

