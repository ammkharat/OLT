IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'PermitElectricalWork')
BEGIN
ALTER TABLE [dbo].[WorkPermit]
	ADD PermitElectricalWork bit NOT NULL DEFAULT (0);
END
GO

IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermitHistory' AND Column_name = 'PermitElectricalWork')
BEGIN
ALTER TABLE [dbo].[WorkPermitHistory]
	ADD PermitElectricalWork bit NOT NULL DEFAULT (0);
END
GO
