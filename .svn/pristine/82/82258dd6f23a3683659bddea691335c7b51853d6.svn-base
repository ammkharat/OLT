

alter table WorkPermitMontrealDetails add NettoyageTransfertHorsSite bit null;
alter table WorkPermitMontrealHistory add NettoyageTransfertHorsSite bit null;
alter table WorkPermitMontrealTemplate add NettoyageTransfertHorsSite tinyint null;
go

update WorkPermitMontrealDetails set NettoyageTransfertHorsSite = 0;
update WorkPermitMontrealHistory set NettoyageTransfertHorsSite = 0;
update WorkPermitMontrealTemplate set NettoyageTransfertHorsSite = 0;   -- 0 == visible and unchecked
go

alter table WorkPermitMontrealDetails alter column NettoyageTransfertHorsSite bit not null;
alter table WorkPermitMontrealHistory alter column NettoyageTransfertHorsSite bit not null;
alter table WorkPermitMontrealTemplate alter column NettoyageTransfertHorsSite tinyint not null;
go






GO

