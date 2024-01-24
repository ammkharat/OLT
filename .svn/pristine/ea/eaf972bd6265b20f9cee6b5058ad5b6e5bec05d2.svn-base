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
		select @cmd = 'DROP TABLE [' + @tablename + ']' 
		exec(@cmd)
		fetch next from curs_tables into @tablename
	end

close curs_tables
deallocate curs_tables
GO


declare @scheme sysname,
        @cmd varchar(1024)


declare curs_scheme cursor for
select 	schemes.[name]
	from 	sys.partition_schemes schemes
	where 	schemes.type = 'PS'
	
open curs_scheme

fetch next from curs_scheme into @scheme
while (@@fetch_status = 0)
	begin
		select @cmd = 'DROP PARTITION SCHEME [' + @scheme + ']' 
		exec(@cmd)
		fetch next from curs_scheme into @scheme
	end

close curs_scheme
deallocate curs_scheme
GO


declare @func sysname,
        @cmd varchar(1024)


declare curs_func cursor for
select 	funcs.[name]
	from 	sys.partition_functions funcs
	where 	funcs.type = 'R'
	
open curs_func

fetch next from curs_func into @func
while (@@fetch_status = 0)
	begin
		select @cmd = 'DROP PARTITION FUNCTION [' + @func + ']' 
		exec(@cmd)
		fetch next from curs_func into @func
	end

close curs_func
deallocate curs_func
GO

