CREATE TABLE [dbo].[PermitRequestMontealWorkPermitMontrealAssociation]
(
PermitRequestId bigint not null,
WorkPermitId bigint not null
)

GO

ALTER TABLE [dbo].[PermitRequestMontealWorkPermitMontrealAssociation]
ADD CONSTRAINT FK_PermitRequestMontreal_PermitRequestMontealWorkPermitMontrealAssociation
FOREIGN KEY(PermitRequestId) REFERENCES PermitRequestMontreal(Id);

ALTER TABLE [dbo].[PermitRequestMontealWorkPermitMontrealAssociation]
ADD CONSTRAINT FK_WorkPermitMontreal_PermitRequestMontealWorkPermitMontrealAssociation
FOREIGN KEY(WorkPermitId) REFERENCES WorkPermitMontreal(Id);

GO




GO

