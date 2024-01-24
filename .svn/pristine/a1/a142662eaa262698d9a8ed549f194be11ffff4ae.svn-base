set nocount on

declare @constname sysname,
        @tablename sysname,
        @cmd varchar(1024)

declare curs_constraints cursor for
select 	constraintnames.[name], tablenames.[name]
	from 	sysobjects constraintnames, sysobjects tablenames
	where 	constraintnames.xtype in ('C', 'F', 'PK', 'UQ', 'D')
	and	(constraintnames.status & 64) = 0
	and     tablenames.[id] = constraintnames.parent_obj
order by constraintnames.xtype
	
open curs_constraints

fetch next from curs_constraints into @constname, @tablename
while (@@fetch_status = 0)
	if (select @tablename) not like 'dt%'
		begin
			select @cmd = 'ALTER TABLE [' + @tablename + '] DROP CONSTRAINT ' + @constname
			exec(@cmd)
			fetch next from curs_constraints into @constname, @tablename
		end
	else
		fetch next from curs_constraints into @constname, @tablename	

close curs_constraints
deallocate curs_constraints
GO
