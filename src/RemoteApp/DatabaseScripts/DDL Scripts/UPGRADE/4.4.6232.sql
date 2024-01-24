ALTER TABLE dbo.PermitRequestEdmonton ALTER COLUMN TaskDescription VARCHAR(MAX);
ALTER TABLE dbo.PermitRequestEdmonton ALTER COLUMN SAPDescription VARCHAR(MAX);

ALTER TABLE dbo.PermitRequestEdmontonHistory ALTER COLUMN TaskDescription VARCHAR(MAX);
ALTER TABLE dbo.PermitRequestEdmontonHistory ALTER COLUMN SAPDescription VARCHAR(MAX);

ALTER TABLE dbo.WorkPermitEdmonton ALTER COLUMN TaskDescription VARCHAR(MAX);
ALTER TABLE dbo.WorkPermitEdmontonHistory ALTER COLUMN TaskDescription VARCHAR(MAX);


GO

