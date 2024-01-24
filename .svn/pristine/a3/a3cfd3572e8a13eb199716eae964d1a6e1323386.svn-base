-----------------------
--- Add Special Protective Clothing  Type Paper Coveralls  to Work Permits
-----------------------
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'SpecialProtectiveClothingTypePaperCoveralls')
BEGIN
ALTER TABLE [dbo].[WorkPermit]
	ADD SpecialProtectiveClothingTypePaperCoveralls bit NOT NULL DEFAULT (0);
END
GO

IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermitHistory' AND Column_name = 'SpecialProtectiveClothingTypePaperCoveralls')
BEGIN
ALTER TABLE [dbo].[WorkPermitHistory]
	ADD SpecialProtectiveClothingTypePaperCoveralls bit NOT NULL DEFAULT (0);
END
GO
