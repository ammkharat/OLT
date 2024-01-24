alter table PermitRequestEdmonton drop column Other1;
alter table PermitRequestEdmonton drop column Other2;
alter table PermitRequestEdmonton drop column Other3;
alter table PermitRequestEdmonton drop column Other4;
GO

EXEC sp_rename 'PermitRequestEdmonton.Other1Value', 'Other1', 'COLUMN';
EXEC sp_rename 'PermitRequestEdmonton.Other2Value', 'Other2', 'COLUMN';
EXEC sp_rename 'PermitRequestEdmonton.Other3Value', 'Other3', 'COLUMN';
EXEC sp_rename 'PermitRequestEdmonton.Other4Value', 'Other4', 'COLUMN';
GO

alter table PermitRequestEdmonton drop column WorkersMonitorNumber;
GO
EXEC sp_rename 'PermitRequestEdmonton.WorkersMonitorNumberValue', 'WorkersMonitorNumber', 'COLUMN';

alter table PermitRequestEdmonton drop column Radio;

GO

alter table PermitRequestEdmontonHistory drop column Other1;
alter table PermitRequestEdmontonHistory drop column Other2;
alter table PermitRequestEdmontonHistory drop column Other3;
alter table PermitRequestEdmontonHistory drop column Other4;
GO

EXEC sp_rename 'PermitRequestEdmontonHistory.Other1Value', 'Other1', 'COLUMN';
EXEC sp_rename 'PermitRequestEdmontonHistory.Other2Value', 'Other2', 'COLUMN';
EXEC sp_rename 'PermitRequestEdmontonHistory.Other3Value', 'Other3', 'COLUMN';
EXEC sp_rename 'PermitRequestEdmontonHistory.Other4Value', 'Other4', 'COLUMN';

alter table PermitRequestEdmontonHistory drop column WorkersMonitorNumber;
GO
alter table PermitRequestEdmontonHistory add WorkersMonitorNumber varchar(20) null;

alter table PermitRequestEdmontonHistory drop column Radio;
alter table PermitRequestEdmontonHistory add RadioChannelNumber varchar(20) null;



GO

