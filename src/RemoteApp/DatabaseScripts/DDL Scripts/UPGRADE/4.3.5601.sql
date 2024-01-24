
alter table dbo.WorkPermitOssa drop column RevalidationDateTime;
alter table dbo.WorkPermitOssa drop column ExtensionTime;
alter table dbo.WorkPermitOssa drop column ExtensionAuthorizedBy;
alter table dbo.WorkPermitOssa drop column IsolationNumber;

alter table dbo.WorkPermitOssaHistory drop column RevalidationDateTime;
alter table dbo.WorkPermitOssaHistory drop column ExtensionTime;
alter table dbo.WorkPermitOssaHistory drop column ExtensionAuthorizedBy;
alter table dbo.WorkPermitOssaHistory drop column IsolationNumber;





GO

