alter table userprintpreference
alter column PrinterName varchar(125) null;

go

update userprintpreference
set PrinterName = null
where PrinterName = 'Current Default Printer';

go

GO
