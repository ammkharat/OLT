alter table PermitAttribute
add Deleted bit null;

go

update PermitAttribute
set Deleted = 0;

go

alter table PermitAttribute
alter column Deleted bit not null;

go

GO
CREATE TABLE [dbo].PermitRequestPermitAttributeAssociation (
	PermitRequestId bigint not null,
	PermitAttributeId bigint not null
)
ON [PRIMARY];
GO


ALTER TABLE [dbo].PermitRequestPermitAttributeAssociation
ADD CONSTRAINT [FK_PermitRequestPermitAttributeAssociation_PermitRequest] 
FOREIGN KEY(PermitRequestId)
REFERENCES [dbo].PermitRequest ([Id])

go


ALTER TABLE [dbo].PermitRequestPermitAttributeAssociation
ADD CONSTRAINT [FK_PermitRequestPermitAttributeAssociation_PermitAttribute] 
FOREIGN KEY(PermitAttributeId)
REFERENCES [dbo].PermitAttribute ([Id])

go



GO
