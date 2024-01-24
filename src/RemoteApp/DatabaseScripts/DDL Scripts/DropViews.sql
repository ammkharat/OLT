 /* This is the graveyard to drop dead views. They have either been renamed or replaced 
   NOTE: Drops of active views (used by the application) should be done 
   with the view creation. */
   
set nocount on

declare @viewname sysname,
        @cmd varchar(1024)

declare curs_views cursor for
select 	viewnames.[name]
	from 	sysobjects viewnames
	where 	viewnames.xtype = 'V'
	and	(viewnames.status & 64) = 0
	and [name] not like 'sys%'
open curs_views

fetch next from curs_views into @viewname
while (@@fetch_status = 0)
	begin
		select @cmd = 'DROP View [' + @viewname + ']' 
		exec(@cmd)
		fetch next from curs_views into @viewname
	end

close curs_views
deallocate curs_views
GO
