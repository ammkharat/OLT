CREATE NONCLUSTERED INDEX [IDX_Tag_Include] ON [dbo].[Tag] 
(
	[Id] ASC
)
INCLUDE ( [Name]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[IDX_TargetAlert_FLOC]') AND name = N'TargetAlert')
DROP INDEX [IDX_TargetAlert_FLOC] ON [dbo].[TargetAlert];

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[_dta_index_TargetAlert_DTO]') AND name = N'TargetAlert')
DROP INDEX [_dta_index_TargetAlert_DTO] ON [dbo].[TargetAlert];

CREATE NONCLUSTERED INDEX [IDX_TargetAlert_DTO]
ON [dbo].[TargetAlert]
([CreatedDateTime] , [FunctionalLocationID] , [TargetAlertStatusID] , [ID])
WITH
(
PAD_INDEX = OFF,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO


CREATE NONCLUSTERED INDEX [IDX_TargetAlert_Priority_DTO] ON [dbo].[TargetAlert] 
(
	[TargetAlertStatusID] ASC,
	[CreatedDateTime] ASC,
	[TargetDefinitionID] ASC,
	[FunctionalLocationID] ASC,
	[ID] ASC,
	[TagID] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]




GO

