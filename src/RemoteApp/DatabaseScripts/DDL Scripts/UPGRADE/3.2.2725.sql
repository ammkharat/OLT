alter table UserLoginHistory
add ClientUri varchar(500) null;

go

update UserLoginHistory
set ClientUri = '';

go

alter table UserLoginHistory
alter column ClientUri varchar(500) not null;

go

sp_RENAME 'EventSinks.ObjRefUri' , 'ClientUri', 'COLUMN'

go



GO
