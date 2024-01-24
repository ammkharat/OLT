IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryBusinessCategoryDefaultSAPNotificationCategory')
	BEGIN
		DROP PROCEDURE [dbo].QueryBusinessCategoryDefaultSAPNotificationCategory
	END
GO

CREATE Procedure [dbo].QueryBusinessCategoryDefaultSAPNotificationCategory
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
	and IsSAPNotificationDefault = 1
GO

GRANT EXEC ON QueryBusinessCategoryDefaultSAPNotificationCategory TO PUBLIC
GO