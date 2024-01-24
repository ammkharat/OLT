



alter table dbo.WorkPermitEdmontonDetails drop column Other1;
alter table dbo.WorkPermitEdmontonDetails drop column Other2;
alter table dbo.WorkPermitEdmontonDetails drop column Other3;
alter table dbo.WorkPermitEdmontonDetails drop column Other4;
go

exec sp_RENAME 'WorkPermitEdmontonDetails.Other1Value' , 'Other1', 'COLUMN'
exec sp_RENAME 'WorkPermitEdmontonDetails.Other2Value' , 'Other2', 'COLUMN'
exec sp_RENAME 'WorkPermitEdmontonDetails.Other3Value' , 'Other3', 'COLUMN'
exec sp_RENAME 'WorkPermitEdmontonDetails.Other4Value' , 'Other4', 'COLUMN'
go

alter table dbo.WorkPermitEdmontonHistory drop column Other1;
alter table dbo.WorkPermitEdmontonHistory drop column Other2;
alter table dbo.WorkPermitEdmontonHistory drop column Other3;
alter table dbo.WorkPermitEdmontonHistory drop column Other4;
go

exec sp_RENAME 'WorkPermitEdmontonHistory.Other1Value' , 'Other1', 'COLUMN'
exec sp_RENAME 'WorkPermitEdmontonHistory.Other2Value' , 'Other2', 'COLUMN'
exec sp_RENAME 'WorkPermitEdmontonHistory.Other3Value' , 'Other3', 'COLUMN'
exec sp_RENAME 'WorkPermitEdmontonHistory.Other4Value' , 'Other4', 'COLUMN'
go




GO

