alter table FormGN1 add Location varchar(128) null;
GO

update FormGN1 set Location = (select Description from FunctionalLocation f where FormGN1.FunctionalLocationId = f.Id)
GO

alter table FormGN1 alter column Location varchar(128) not null;


GO

