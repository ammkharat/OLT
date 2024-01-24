IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftsBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftsBySiteId
	END
GO

CREATE Procedure dbo.QueryShiftsBySiteId
	(
		@siteId int
	)
AS

if (@siteId !=5)
SELECT 
	Shift.* ,
   	
	siteconfig.PreShiftPaddingInMinutes,
	siteconfig.PostShiftPaddingInMinutes
FROM 
	Shift
	INNER JOIN SiteConfiguration siteconfig ON siteconfig.SiteId = Shift.SiteId   	
WHERE 
	Shift.SiteId=@siteId

else
SELECT 
	Shift.* ,
   	
	siteconfig.PreShiftPaddingInMinutes,
	siteconfig.PostShiftPaddingInMinutes
FROM 
	Shift
	INNER JOIN SiteConfiguration siteconfig ON siteconfig.SiteId = Shift.SiteId   	
WHERE 

	Shift.SiteId=@siteId and Name in ('12DA','12NT','6DA','6NT')
GO

GRANT EXEC ON QueryShiftsBySiteId TO PUBLIC
GO