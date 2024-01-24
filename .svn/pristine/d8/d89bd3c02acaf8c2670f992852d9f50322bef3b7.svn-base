IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryBusinessCategoryDefaultSAPWorkOrderCategory')
	BEGIN
		DROP PROCEDURE [dbo].QueryBusinessCategoryDefaultSAPWorkOrderCategory
	END
GO

CREATE Procedure [dbo].QueryBusinessCategoryDefaultSAPWorkOrderCategory
	(
		@SiteId bigint
	)
AS

select * 
from 
	BusinessCategory
where 
	Deleted = 0 
	and SiteId = @SiteId
	and IsSAPWorkOrderDefault = 1
GO

GRANT EXEC ON QueryBusinessCategoryDefaultSAPWorkOrderCategory TO PUBLIC
GO 