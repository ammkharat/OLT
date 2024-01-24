ALTER INDEX [PK_WorkPermitMontreal] ON [dbo].[WorkPermitMontreal] REBUILD
WITH
(
FILLFACTOR = 90
)
GO

ALTER INDEX [PK_PermitRequestMontreal] ON [dbo].[PermitRequestMontreal] REBUILD
WITH
(
FILLFACTOR = 90
)
GO

ALTER INDEX [PK_DocumentLink] ON [dbo].[DocumentLink] REBUILD
WITH ( 
FILLFACTOR = 90
)
GO

ALTER INDEX [PK_WorkPermitEdmontonDetails] ON [dbo].[WorkPermitEdmontonDetails] REBUILD
WITH
(
FILLFACTOR = 90
)
GO

ALTER INDEX [IDX_WorkPermitMontrealHistory] ON [dbo].[WorkPermitMontrealHistory] REBUILD 
WITH ( 
FILLFACTOR = 100
)
GO

ALTER INDEX [IDX_SummaryLogFunctionalLocation] ON [dbo].[SummaryLogFunctionalLocation] REBUILD
WITH
(
FILLFACTOR = 90
)
GO

ALTER INDEX [PK_PermitRequestEdmonton] ON [dbo].[PermitRequestEdmonton] REBUILD
WITH
(
FILLFACTOR = 90
)
GO

DROP INDEX [IDX_ActionItemDefinition_Floc] 
ON [dbo].[ActionItemFunctionalLocation];
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_ActionItemFunctionalLocation_Floc]
ON [dbo].[ActionItemFunctionalLocation]
([FunctionalLocationId] , [ActionItemId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 90,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO

ALTER INDEX [IDX_PermitRequestEdmontonHistory_Id] ON [dbo].[PermitRequestEdmontonHistory] REORGANIZE
GO

ALTER INDEX [IDX_WorkPermitEdmontonHistory] ON [dbo].[WorkPermitEdmontonHistory] REORGANIZE
GO

ALTER INDEX [IDX_ShiftHandoverQuestionnaireRead_UserId] ON [dbo].[ShiftHandoverQuestionnaireRead] REBUILD
WITH
(
FILLFACTOR = 90
)
GO

declare @sqlDropConstraint NVARCHAR(1000)
select 
@sqlDropConstraint = 'ALTER TABLE [' + tbl.[name] + '] DROP CONSTRAINT ' + idx.[name]
from sys.indexes idx 
inner join sys.tables tbl on idx.object_id = tbl.object_id 
where idx.[type] <> 0 and
        tbl.[name] = 'User' 
        and idx.[name] like 'UQ__%'
exec sp_executeSql @sqlDropConstraint

CREATE UNIQUE NONCLUSTERED INDEX [IDX_User_Unique_Username]
ON [dbo].[User]
([Username])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO

ALTER INDEX [IDX_TargetAlert_FLOC] ON [dbo].[TargetAlert] REORGANIZE;
GO

ALTER INDEX [IDX_TargetAlert_DefId] ON [dbo].[TargetAlert] REORGANIZE;
GO

ALTER INDEX [IDX_ShiftHandoverQuestionnaireFunctionalLocation] ON [dbo].[ShiftHandoverQuestionnaireFunctionalLocation] REBUILD
WITH
(
FILLFACTOR = 90
)
GO

ALTER INDEX [IDX_SAPNOTIFICATION] ON [dbo].[SAPNotification] REORGANIZE
GO

ALTER INDEX [IDX_PermitRequestMontrealHistory_Id] ON [dbo].[PermitRequestMontrealHistory] REORGANIZE
GO

ALTER INDEX [IDX_LogFunctionalLocation] ON [dbo].[LogFunctionalLocation] REBUILD
WITH
(
FILLFACTOR = 90
)
GO

ALTER INDEX [IDX_LogRead_UserId] ON [dbo].[LogRead] REBUILD
WITH
(
FILLFACTOR = 90
)
GO

ALTER INDEX [IDX_UserLoginHistory_UserId_LoginDateTime] ON [dbo].[UserLoginHistory] REBUILD
WITH
(
FILLFACTOR = 80
)
GO


GO

