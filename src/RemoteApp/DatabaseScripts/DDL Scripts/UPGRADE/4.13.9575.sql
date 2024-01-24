ALTER INDEX [PK_WorkPermitEdmontonDetails]
ON [dbo].[WorkPermitEdmontonDetails]
REBUILD;

ALTER INDEX [PK_DeviationAlert]
ON [dbo].[DeviationAlert]
REBUILD

ALTER INDEX [PK_PermitRequestEdmonton] ON [dbo].[PermitRequestEdmonton] REORGANIZE
GO

ALTER INDEX [IDX_TargetAlert_DefId] ON [dbo].[TargetAlert] REORGANIZE
GO

ALTER INDEX [IDX_PermitRequestLubesHistory_Id] ON [dbo].[PermitRequestLubesHistory] REORGANIZE
GO

ALTER INDEX [IDX_TargetAlert_DTO]
ON [dbo].[TargetAlert]
REBUILD

ALTER INDEX [IDX_TargetAlert_FLOC]
ON [dbo].[TargetAlert]
REBUILD

ALTER INDEX [PK_WorkPermitLubes] ON [dbo].[WorkPermitLubes] REORGANIZE
GO

ALTER INDEX [IDX_FormGN7History]
ON [dbo].[FormGN7History]
REBUILD

ALTER INDEX [PK_PermitRequestLubes] ON [dbo].[PermitRequestLubes] REORGANIZE
GO

ALTER INDEX [PK_TargetDefinition] ON [dbo].[TargetDefinition] REORGANIZE
GO

ALTER INDEX [IDX_PermitRequestEdmontonHistory_Id]
ON [dbo].[PermitRequestEdmontonHistory]
REBUILD


GO

