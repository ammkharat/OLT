/* This is the graveyard to drop dead stored procedures. They have either been renamed or replaced 
   NOTE: Drops of active stored procedures (used by the application) should be done 
   with the stored procedure creation. */

set nocount on

-- First make everything owned by dbo. There is a problem that some Stored Procs were created without the dbo owner prefix.
declare @storedprocname sysname,
	    @owner sysname,
        @cmd varchar(1024)

declare curs_storedprocs cursor for
select 	storedprocnames.[name], sysusers.[name]
	from 	sysobjects storedprocnames, sysusers
	where storedprocnames.uid = sysusers.uid
	and storedprocnames.xtype = 'P'
	and (storedprocnames.status & 64) = 0
	and storedprocnames.[name] not like 'dt_%'
	and sysusers.[name] != 'dbo'
open curs_storedprocs

fetch next from curs_storedprocs into @storedprocname, @owner
while (@@fetch_status = 0)
	begin
		select @cmd = '[' + @owner + '].[' + @storedprocname + ']'
		exec sp_changeobjectowner @cmd, 'dbo'
		fetch next from curs_storedprocs into @storedprocname, @owner
	end

close curs_storedprocs
deallocate curs_storedprocs
GO

declare @storedprocname sysname,
        @cmd varchar(1024)

declare curs_storedprocs cursor for
select 	storedprocnames.[name]
	from 	sysobjects storedprocnames
	where 	storedprocnames.xtype = 'P'
	and	(storedprocnames.status & 64) = 0
	and [name] not like 'dt_%'
open curs_storedprocs

fetch next from curs_storedprocs into @storedprocname
while (@@fetch_status = 0)
	begin
		select @cmd = 'DROP Procedure [dbo].[' + @storedprocname + ']' 
		exec(@cmd)
		fetch next from curs_storedprocs into @storedprocname
	end

close curs_storedprocs
deallocate curs_storedprocs
GO
