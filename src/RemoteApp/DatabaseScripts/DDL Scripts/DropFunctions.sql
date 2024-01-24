 /* This is the graveyard to drop dead functions. They have either been renamed or replaced 
   NOTE: Drops of active functions (used by the application) should be done 
   with the function creation. */
   
set nocount on

declare @functionname sysname,
        @cmd varchar(1024)

declare curs_functions cursor for
select 	udfs.[name]
	from 	sysobjects udfs
	where 	udfs.xtype  in (N'FN', N'IF', N'TF')
	and	(udfs.status & 64) = 0
	and udfs.[name] not like 'dt_%'	
open curs_functions

fetch next from curs_functions into @functionname
while (@@fetch_status = 0)
	begin
		select @cmd = 'DROP FUNCTION [' + @functionname + ']' 
		exec(@cmd)
		fetch next from curs_functions into @functionname
	end

close curs_functions
deallocate curs_functions
GO