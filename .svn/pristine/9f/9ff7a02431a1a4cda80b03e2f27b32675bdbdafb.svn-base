CREATE NONCLUSTERED INDEX IDX_ActionItem_FunctionalLocation
ON ActionItem (FunctionalLocationID)
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_ActionItem_LastModifiedUser
ON ActionItem (LastModifiedUserId)
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_ActionItemDef_LastModifiedUser
ON ActionItemDefinition (LastModifiedUserId)
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_ActionItemDef_Name
ON ActionItemDefinition ([Name])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

/****** Object:  Index [IDX_ActionItemDefinitionHistory_Id]    Script Date: 12/16/2008 11:12:16 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionHistory]') AND name = N'IDX_ActionItemDefinitionHistory_Id')
DROP INDEX [IDX_ActionItemDefinitionHistory_Id] ON [dbo].[ActionItemDefinitionHistory] WITH ( ONLINE = OFF )

CREATE CLUSTERED INDEX IDX_ActionItemDefinitionHistory_Id
ON ActionItemDefinitionHistory ([Id])
WITH FILLFACTOR = 90
GO


CREATE NONCLUSTERED INDEX IDX_Comment_User
ON Comment ([CreatedUserId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE UNIQUE CLUSTERED INDEX PK_FunctionalLocation
ON FunctionalLocation ([Id])
WITH DROP_EXISTING
GO

CREATE NONCLUSTERED INDEX IDX_FunctionalLocation_FullHierarchy
ON FunctionalLocation ([FullHierarchy])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_Log_FLOC
ON [Log] ([FunctionalLocationId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_Log_ReplyToLog
ON [Log] ([ReplyToLogId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE CLUSTERED INDEX IDX_LogHistory
ON [LogHistory] ([Id])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_SAPNotification_FunctionalLocation
ON [SAPNotification] ([FunctionalLocationId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_TagName_Site
ON [Tag] ([SiteId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_TargetAlert_FLOC
ON [TargetAlert] ([FunctionalLocationId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_TargetAlertResponse_TargetAlert
ON [TargetAlertResponse] ([TargetAlertId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_TargetAlertResponse_Comment
ON [TargetAlertResponse] ([CommentId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_TargetAlertResponse_FLOC
ON [TargetAlertResponse] ([ResponsibleFunctionalLocationId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_TargetDefinition_FLOC
ON [TargetDefinition] ([FunctionalLocationId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_TargetDefinition_LastModifiedUserId
ON [TargetDefinition] ([LastModifiedUserId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_TargetDefinition_Name
ON [TargetDefinition] ([Name])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE CLUSTERED INDEX IDX_TargetDefinitionHistory
ON [TargetDefinitionHistory] ([Id])
WITH DROP_EXISTING, FILLFACTOR = 80
GO

CREATE NONCLUSTERED INDEX IDX_User_ParentOrgUnit
ON [User] ([ParentOrgUnitId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

CREATE NONCLUSTERED INDEX IDX_User_Role
ON [User] ([RoleId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'PK_UserLayoutPreference')
BEGIN
ALTER TABLE dbo.UserLayoutPreference ADD CONSTRAINT
	PK_UserLayoutPreference PRIMARY KEY CLUSTERED 
	(UserId) ON [PRIMARY]
END
GO

CREATE CLUSTERED INDEX IDX_UserSite_UserId
ON [UserSite] ([UserId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO