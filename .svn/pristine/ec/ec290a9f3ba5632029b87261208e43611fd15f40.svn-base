
alter table WorkPermitEdmonton add IssuedToCompany bit NULL;
go

update WorkPermitEdmonton set IssuedToCompany = 1 where [Company] is not null;
update WorkPermitEdmonton set IssuedToCompany = 0 where Company is null;
go

alter table WorkPermitEdmonton alter column IssuedToCompany bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add IssuedToCompany bit NULL;
go

update WorkPermitEdmontonHistory set IssuedToCompany = 1 where [Company] is not null;
update WorkPermitEdmontonHistory set IssuedToCompany = 0 where Company is null;
go

alter table WorkPermitEdmontonHistory alter column IssuedToCompany bit NOT NULL;
go


GO

