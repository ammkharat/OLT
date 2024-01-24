alter table WorkPermit
add Version varchar(10) null;

go

update WorkPermit
set Version = 3.2;

go

alter table WorkPermit
alter column Version varchar(10) not null;

go


GO
