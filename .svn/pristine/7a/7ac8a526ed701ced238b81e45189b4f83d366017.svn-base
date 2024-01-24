alter table PermitRequestEdmonton add FormGN1Id bigint NULL;
alter table PermitRequestEdmonton add GN1 bit NULL;
GO

update PermitRequestEdmonton set GN1 = 0;

alter table PermitRequestEdmonton alter column GN1 bit NOT NULL;


GO

