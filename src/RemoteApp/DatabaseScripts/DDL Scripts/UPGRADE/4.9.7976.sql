

ALTER TABLE dbo.WorkPermitLubes ADD UsePreviousPermitAnswered bit NULL;
GO
UPDATE dbo.WorkPermitLubes SET UsePreviousPermitAnswered = 0
ALTER TABLE dbo.WorkPermitLubes ALTER COLUMN UsePreviousPermitAnswered bit NOT NULL;
GO





GO

