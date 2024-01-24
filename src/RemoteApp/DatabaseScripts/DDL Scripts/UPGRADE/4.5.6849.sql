ALTER TABLE dbo.WorkPermitEdmonton ADD UsePreviousPermitAnswered bit NULL;
GO
UPDATE dbo.WorkPermitEdmonton SET UsePreviousPermitAnswered = 0
ALTER TABLE dbo.WorkPermitEdmonton ALTER COLUMN UsePreviousPermitAnswered bit NOT NULL;
GO


GO

