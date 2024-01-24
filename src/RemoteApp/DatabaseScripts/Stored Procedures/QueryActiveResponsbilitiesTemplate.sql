IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActiveResponsbilitiesTemplate')
	BEGIN
		DROP PROCEDURE [dbo].QueryActiveResponsbilitiesTemplate
	END
GO

CREATE Procedure dbo.QueryActiveResponsbilitiesTemplate
AS

SELECT Id From [dbo].[FormTemplate] WHERE FormTypeId = 5 and Deleted = 0 and TemplateKey = 'responsibilities'
GO

GRANT EXEC ON QueryActiveResponsbilitiesTemplate TO PUBLIC
GO

