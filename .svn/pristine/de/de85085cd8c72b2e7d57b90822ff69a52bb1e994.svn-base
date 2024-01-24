


alter table dbo.WorkPermitEdmonton add IssuedToSuncor bit null;
go

update dbo.WorkPermitEdmonton set IssuedToSuncor = 1 where IssuedToId = 0;
update dbo.WorkPermitEdmonton set IssuedToSuncor = 0 where IssuedToId != 0;
go

alter table dbo.WorkPermitEdmonton alter column IssuedToSuncor bit not null;
alter table dbo.WorkPermitEdmonton drop column IssuedToId;
go




alter table dbo.PermitRequestEdmonton add IssuedToSuncor bit null;
go

update dbo.PermitRequestEdmonton set IssuedToSuncor = 1 where IssuedToId = 0;
update dbo.PermitRequestEdmonton set IssuedToSuncor = 0 where IssuedToId != 0;
go

alter table dbo.PermitRequestEdmonton alter column IssuedToSuncor bit not null;
alter table dbo.PermitRequestEdmonton drop column IssuedToId;
go




GO

