IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDoesSiteUseLogBasedDirectives')
	BEGIN
		DROP  Procedure  QueryDoesSiteUseLogBasedDirectives
	END

GO

CREATE Procedure [dbo].QueryDoesSiteUseLogBasedDirectives
	(
		@SiteId bigint
	)
AS

SELECT 
	sc.UseLogBasedDirectives
FROM 
	SiteConfiguration sc
WHERE 
	sc.SiteId = @SiteId
GO

GRANT EXEC ON QueryDoesSiteUseLogBasedDirectives TO PUBLIC
GO