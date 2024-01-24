IF EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'UserSite' AND Column_name = 'IsDefaultRole')
BEGIN
	alter table UserSite
	drop column IsDefaultRole
END

go

IF EXISTS(SELECT * FROM information_schema.tables WHERE table_name = 'UserSite')
BEGIN

	exec sp_rename 'UserSite',  'UserSiteRole'

END

go

GO
