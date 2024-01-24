IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryBusinessCategoryBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryBusinessCategoryBySiteId
	END
GO

CREATE Procedure [dbo].QueryBusinessCategoryBySiteId
	(
		@SiteId bigint
	)
AS

SELECT * 
FROM 
	BusinessCategory 
where 
	deleted = 0
	and SiteId = @SiteId
GO

GRANT EXEC ON QueryBusinessCategoryBySiteId TO PUBLIC
GO