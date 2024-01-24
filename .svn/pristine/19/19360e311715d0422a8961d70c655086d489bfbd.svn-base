IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitMontrealTemplates')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllWorkPermitMontrealTemplates
	END
GO

-- Get all WorkPermitMontrealTemplates that have not been Deleted
CREATE Procedure [dbo].QueryAllWorkPermitMontrealTemplates
AS
SELECT * 
FROM WorkPermitMontrealTemplate;
GO

GRANT EXEC ON QueryAllWorkPermitMontrealTemplates TO PUBLIC
GO