IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTagsByFilter')
	BEGIN
		DROP PROCEDURE [dbo].QueryTagsByFilter
	END
GO

CREATE Procedure [dbo].QueryTagsByFilter
	(
		@filter varchar(MAX),
		@siteId varchar(100)
	)

AS

BEGIN
	declare @Sql varchar(MAX)

	if(@siteId = '3' OR @siteId = '6' OR @siteId = '11')
	
	set @SQL = 'SELECT t.Id, Name, t.Description, Units, t.SiteId, t.Deleted, ScadaConnectionInfoId, sci.Description as ScadaProviderDescription 
	FROM Tag t INNER JOIN ScadaConnectionInfo sci ON t.ScadaConnectionInfoId = sci.Id 
	 WHERE t.Deleted = 0 AND t.SiteId in (3,6,11)  AND t.' + @filter + ' Order by t.Name'

	Else

	set @SQL = 'SELECT t.Id, Name, t.Description, Units, t.SiteId, t.Deleted, ScadaConnectionInfoId, sci.Description as ScadaProviderDescription 
	FROM Tag t INNER JOIN ScadaConnectionInfo sci ON t.ScadaConnectionInfoId = sci.Id 
	WHERE t.Deleted = 0 AND t.SiteId = ' + @siteId +'AND t.' + @filter + ' Order by t.Name'
	exec(@SQL)
END
GO

GRANT EXEC ON QueryTagsByFilter TO PUBLIC
GO