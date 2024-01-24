set nocount on

declare @tablename sysname,
        @cmd varchar(1024)


declare curs_tables cursor for
select 	tablenames.[name]
	from 	sysobjects tablenames
	where 	tablenames.xtype = 'U'
	and	(tablenames.status & 64) = 0
	
open curs_tables

fetch next from curs_tables into @tablename
while (@@fetch_status = 0)
	begin
		select @cmd = 'ALTER TABLE [' + @tablename + '] WITH CHECK CHECK CONSTRAINT ALL' 
		exec(@cmd)
		fetch next from curs_tables into @tablename
	end

close curs_tables
deallocate curs_tables
GO  



