IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftById')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftById
	END
GO

CREATE Procedure dbo.QueryShiftById
	(
	@id int
	)
AS
SELECT 
	Shift.* ,
   	siteconfig.PreShiftPaddingInMinutes,
	siteconfig.PostShiftPaddingInMinutes
FROM 
	Shift
	INNER JOIN SiteConfiguration siteconfig ON siteconfig.SiteId = Shift.SiteId
WHERE 
	Shift.Id=@Id
GO

GRANT EXEC ON [QueryShiftById] TO PUBLIC
GO