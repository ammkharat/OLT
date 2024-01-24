IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllShifts')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllShifts
	END
GO

CREATE Procedure [dbo].QueryAllShifts
AS

SELECT 
	Shift.*,
   	
	siteconfig.PreShiftPaddingInMinutes,
	siteconfig.PostShiftPaddingInMinutes

FROM
	Shift
	INNER JOIN SiteConfiguration siteconfig ON siteconfig.SiteId = Shift.SiteId
GO

GRANT EXEC ON QueryAllShifts TO PUBLIC
GO