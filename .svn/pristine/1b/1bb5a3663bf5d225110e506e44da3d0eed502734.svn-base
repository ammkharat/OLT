IF EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'ToolsSandblaster')
BEGIN
ALTER TABLE [dbo].[WorkPermit]
	DROP CONSTRAINT
		[DF_WorkPermit_ToolsSandblaster]
ALTER TABLE [dbo].[WorkPermit] 
	DROP COLUMN
		[ToolsSandblaster]

ALTER TABLE [dbo].[WorkPermitHistory]
	DROP CONSTRAINT
		[DF_WorkPermitHistory_ToolsSandblaster]
ALTER TABLE [dbo].[WorkPermitHistory] 
	DROP COLUMN
		[ToolsSandblaster]
END
GO
