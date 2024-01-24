IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormTemplate')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormTemplate
	END
GO

CREATE Procedure dbo.QueryFormTemplate
(
@SiteId int
)
AS

SELECT ft.*
FROM FormTemplate ft
WHERE ft.Deleted != 1 AND
SiteId = @SiteId
ORDER BY FormTypeId, Name
	
GO

GRANT EXEC ON QueryFormTemplate TO PUBLIC
GO