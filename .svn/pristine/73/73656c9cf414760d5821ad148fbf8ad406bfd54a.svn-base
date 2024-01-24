CREATE TABLE [dbo].WorkPermitMontrealPermitAttributeAssociation (
	WorkPermitMontrealId bigint not null,
	PermitAttributeId bigint not null
)
ON [PRIMARY];
GO


ALTER TABLE [dbo].WorkPermitMontrealPermitAttributeAssociation
ADD CONSTRAINT [FK_WorkPermitMontrealPermitAttributeAssociation_WorkPermitMontreal] 
FOREIGN KEY(WorkPermitMontrealId)
REFERENCES [dbo].WorkPermitMontreal ([Id])

go


ALTER TABLE [dbo].WorkPermitMontrealPermitAttributeAssociation
ADD CONSTRAINT [FK_WorkPermitMontrealPermitAttributeAssociation_PermitAttribute] 
FOREIGN KEY(PermitAttributeId)
REFERENCES [dbo].PermitAttribute ([Id])

go


GO
