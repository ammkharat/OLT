alter table WorkPermitMontreal
add SourceId int null;

go

update WorkPermitMontreal
set SourceId = 0;

go

alter table WorkPermitMontreal
alter column SourceId int not null;

go



GO
