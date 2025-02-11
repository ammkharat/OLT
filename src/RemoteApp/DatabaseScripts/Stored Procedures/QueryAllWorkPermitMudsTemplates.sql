
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitMudsTemplates')
	BEGIN
		DROP Procedure [dbo].QueryAllWorkPermitMudsTemplates
	END
GO

-- Get all WorkPermitMudsTemplates that have not been Deleted
CREATE Procedure [dbo].[QueryAllWorkPermitMudsTemplates]
AS
SELECT * 
FROM WorkPermitMudsTemplate;
GO


GRANT EXEC ON QueryAllWorkPermitMudsTemplates TO PUBLIC
GO

