IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitMontrealTemplatesNotDeleted')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllWorkPermitMontrealTemplatesNotDeleted
	END
GO

-- Get all WorkPermitMontrealTemplates that have not been Deleted
CREATE Procedure [dbo].QueryAllWorkPermitMontrealTemplatesNotDeleted
AS
SELECT * 
FROM WorkPermitMontrealTemplate
WHERE Deleted = 0;
GO

GRANT EXEC ON QueryAllWorkPermitMontrealTemplatesNotDeleted TO PUBLIC
GO