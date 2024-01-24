ALTER TABLE [dbo].[DocumentLink] NOCHECK CONSTRAINT ALL
GO

ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN ActionItemId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN ActionItemDefinitionId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN FormGN24Id BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN FormGN6Id BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN FormGN75AId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN LogDefinitionId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN LogId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN PermitRequestEdmontonId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN PermitRequestLubesId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN PermitRequestMontrealId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN SummaryLogId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN TargetAlertId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN TargetDefinitionId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN WorkPermitEdmontonId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN WorkPermitId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN WorkPermitLubesId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink] ALTER COLUMN WorkPermitMontrealId BIGINT SPARSE NULL;
GO

ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT ALL
GO

ALTER TABLE [dbo].[DocumentLink] ADD  CONSTRAINT [FK_DocumentLink_ActionItem]
FOREIGN KEY ([ActionItemId]) REFERENCES [dbo].[ActionItem] ( [Id] )
GO

ALTER TABLE [dbo].[DocumentLink] ADD  CONSTRAINT [FK_DocumentLink_TargetAlert]
FOREIGN KEY ([TargetAlertId]) REFERENCES [dbo].[TargetAlert] ( [Id] )
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_ActionItem] ON [dbo].[DocumentLink] 
	([ActionItemId])
WHERE (Deleted = 0 and ActionItemId IS NOT NULL)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_ActionItemDefinition] ON [dbo].[DocumentLink] 
	([ActionItemDefinitionId])
WHERE (Deleted = 0 and ActionItemDefinitionId IS NOT NULL)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_Log] ON [dbo].[DocumentLink] 
	([LogId])
WHERE (Deleted = 0 and LogId IS NOT NULL)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_LogDefinition] ON [dbo].[DocumentLink] 
	([LogDefinitionId])
WHERE (Deleted = 0 and LogDefinitionId IS NOT NULL)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_PermitRequestEdmonton] ON [dbo].[DocumentLink] 
	([PermitRequestEdmontonId])
WHERE (Deleted = 0 and PermitRequestEdmontonId IS NOT NULL)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_PermitRequestLubes] ON [dbo].[DocumentLink] 
	([PermitRequestLubesId])
WHERE (Deleted = 0 and PermitRequestLubesId IS NOT NULL)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_PermitRequestMontreal] ON [dbo].[DocumentLink] 
	([PermitRequestMontrealId])
WHERE (Deleted = 0 and PermitRequestMontrealId IS NOT NULL)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_SummaryLog] ON [dbo].[DocumentLink] 
	([SummaryLogId])
WHERE (Deleted = 0 and SummaryLogId IS NOT NULL)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [Idx_DocumentLink_TargetDefinitionId] ON [dbo].[DocumentLink]
	([TargetDefinitionId])
WHERE (Deleted = 0 and TargetDefinitionId IS NOT NULL)	
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_WorkPermitEdmonton] ON [dbo].[DocumentLink] 
	([WorkPermitEdmontonId])
WHERE (Deleted = 0 and WorkPermitEdmontonId IS NOT NULL)		
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_WorkPermit] ON [dbo].[DocumentLink] 
	([WorkPermitId])
WHERE (Deleted = 0 and WorkPermitId IS NOT NULL)		
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_WorkPermitLubes] ON [dbo].[DocumentLink] 
	([WorkPermitLubesId])
WHERE (Deleted = 0 and WorkPermitLubesId IS NOT NULL)		
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_WorkPermitMontreal] ON [dbo].[DocumentLink] 
	([WorkPermitMontrealId])
WHERE (Deleted = 0 and WorkPermitMontrealId IS NOT NULL)		
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_FormGN24] ON [dbo].[DocumentLink] 
	([FormGN24Id])
WHERE (Deleted = 0 and FormGN24Id IS NOT NULL)		
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_FormGN6] ON [dbo].[DocumentLink] 
	([FormGN6Id])
WHERE (Deleted = 0 and FormGN6Id IS NOT NULL)		
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_FormGN75A] ON [dbo].[DocumentLink] 
	([FormGN75AId])
WHERE (Deleted = 0 and FormGN75AId IS NOT NULL)		
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_DocumentLink_FormGN75B] ON [dbo].[DocumentLink] 
	([FormGN75BId])
WHERE (Deleted = 0 and FormGN75BId IS NOT NULL)		
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO


GO

