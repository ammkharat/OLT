update site set TimeZone = 'Eastern Standard Time' where [Name] = 'Sarnia'
update site set timeZone = 'Mountain Standard Time' where [Name] != 'Sarnia'
GO
