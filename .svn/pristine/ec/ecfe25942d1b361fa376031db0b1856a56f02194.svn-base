

alter table dbo.WorkPermitEdmonton add PermitRequestCreatedByUserId bigint null
go

ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_PermitRequestCreatedByUser] FOREIGN KEY([PermitRequestCreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

update WorkPermitEdmonton
set WorkPermitEdmonton.PermitRequestCreatedByUserId = PermitRequestEdmonton.CreatedByUserId
from WorkPermitEdmonton
inner join PermitRequestEdmonton on PermitRequestEdmonton.Id = WorkPermitEdmonton.PermitRequestId
go





GO

