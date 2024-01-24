insert into FunctionalLocationOperationalMode
select Id,0,0,GETDATE() from FunctionalLocation  where Level in (1,2) and Deleted = 0 



GO

