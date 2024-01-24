alter table PermitRequestEdmonton add AllRequiredFormsCompleted bit null;
GO

update PermitRequestEdmonton set AllRequiredFormsCompleted = 0;
GO

alter table PermitRequestEdmonton alter column AllRequiredFormsCompleted bit not null;
GO

alter table PermitRequestEdmontonHistory add AllRequiredFormsCompleted bit null;
GO

update PermitRequestEdmontonHistory set AllRequiredFormsCompleted = 0;
GO

alter table PermitRequestEdmontonHistory alter column AllRequiredFormsCompleted bit not null;


GO

