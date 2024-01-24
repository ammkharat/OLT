alter table WorkPermitMontreal
add Deleted bit null

go

update WorkPermitMontreal
set Deleted = 0

go

alter table WorkPermitMontreal
alter column Deleted bit not null

go
GO
