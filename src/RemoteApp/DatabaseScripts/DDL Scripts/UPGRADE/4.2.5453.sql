

sp_RENAME 'WorkPermitMontrealHistory.[FunctionalLocation]' , 'FunctionalLocations', 'COLUMN'
go

alter table WorkPermitMontrealHistory
alter column FunctionalLocations varchar(max) not null;
go



GO

