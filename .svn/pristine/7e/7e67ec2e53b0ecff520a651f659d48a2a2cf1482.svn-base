set nocount on

declare @triggername sysname,
        @cmd varchar(1024)

declare curs_triggers cursor for
select 	triggernames.[name]
	from 	sysobjects triggernames
	where 	triggernames.xtype = 'TR'
	and	(triggernames.status & 64) = 0

open curs_triggers

fetch next from curs_triggers into @triggername
while (@@fetch_status = 0)
	begin
		select @cmd = 'DROP TRIGGER [' + @triggername + ']'
		exec(@cmd)
		fetch next from curs_triggers into @triggername
	end

close curs_triggers
deallocate curs_triggers
GO
 