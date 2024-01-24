DROP INDEX [IDX_WorkPermitMontrealPermitAttributeAssociation] ON [dbo].[WorkPermitMontrealPermitAttributeAssociation];

ALTER TABLE [dbo].[WorkPermitMontrealPermitAttributeAssociation] ADD CONSTRAINT [PK_WorkPermitMontrealPermitAttribAssoc] 
PRIMARY KEY CLUSTERED ([WorkPermitMontrealId] ASC, [PermitAttributeId] ASC);

ALTER TABLE [dbo].[WorkPermitCloseConfiguration] ADD CONSTRAINT [PK_WorkPermitCloseConfiguration] 
PRIMARY KEY CLUSTERED ([SiteId] , [StatusId]);

ALTER TABLE [dbo].[Userworkpermitdefaulttimespreference] ADD CONSTRAINT [PK_Userworkpermitdefaulttimespreference] 
PRIMARY KEY CLUSTERED ([Id]);

ALTER TABLE [dbo].[TargetDefinitionAssociation] ADD CONSTRAINT [PK_TargetDefinitionAssociation] 
PRIMARY KEY CLUSTERED ([ParentTargetDefinitionId], [ChildTargetDefinitionId]);

ALTER TABLE [dbo].[SiteFunctionalArea] ADD CONSTRAINT [PK_SiteFunctionalLocation]
PRIMARY KEY CLUSTERED ([SiteId] , [FunctionalArea] );

ALTER TABLE [dbo].[SiteConfigurationDefaults] ADD CONSTRAINT [PK_SiteConfigurationDefaults] 
PRIMARY KEY CLUSTERED ([SiteId]);

ALTER TABLE [dbo].[SiteConfiguration] DROP CONSTRAINT [UQ_SiteConfiguration];

ALTER TABLE [dbo].[SiteConfiguration] ADD CONSTRAINT [PK_SiteConfiguration]
PRIMARY KEY CLUSTERED ([SiteId] );

ALTER TABLE [dbo].[ShiftHandoverConfigurationWorkAssignment] ADD CONSTRAINT [PK_ShiftHandoverConfigurationWorkAssignment]
	PRIMARY KEY CLUSTERED ([ShiftHandoverConfigurationId] , [WorkAssignmentId] );
	
DROP INDEX [IDX_SapWorkOrderOperation] ON [dbo].[SapWorkOrderOperation];

ALTER TABLE [dbo].[SapWorkOrderOperation] 
ADD CONSTRAINT [PK_SapWorkOrderOperation] PRIMARY KEY ([Id] ASC);

CREATE NONCLUSTERED INDEX [IDX_SapWorkOrderOperatoin]
ON [dbo].[SapWorkOrderOperation]
([WorkOrderNumber] , [OperationNumber], [SubOperation] );

ALTER TABLE [dbo].[RolePermission] DROP CONSTRAINT [UK_RolePermission];

ALTER TABLE [dbo].[RolePermission]
ADD  CONSTRAINT [PK_RolePermission]
PRIMARY KEY CLUSTERED ([RoleId] , [RoleElementId] , [CreatedByRoleId] );

ALTER TABLE [dbo].[RoleElementTemplate]
DROP CONSTRAINT [UK_RoleElementTemplate];

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[RoleElementTemplate]') AND name = N'IDX_ROLEELEMENTTEMPLATE_ROLE')
	BEGIN
		DROP INDEX [IDX_ROLEELEMENTTEMPLATE_ROLE] ON [dbo].[RoleElementTemplate];
	END
GO



ALTER TABLE [dbo].[RoleElementTemplate] ADD CONSTRAINT [PK_RoleElementTemplate]
PRIMARY KEY CLUSTERED ([RoleId] , [RoleElementId] );

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestOssaPermitAttributeAssociation]') AND name = N'IDX_PermitRequestOssaPermitAttributeAssociation')
	BEGIN
		DROP INDEX [IDX_PermitRequestOssaPermitAttributeAssociation] ON [dbo].[PermitRequestOssaPermitAttributeAssociation];
	END
GO

ALTER TABLE [dbo].[PermitRequestOssaPermitAttributeAssociation] ADD CONSTRAINT [PK_PermitRequestOssaPermitAttributeAssociation] 
PRIMARY KEY CLUSTERED ([PermitRequestOssaId] , [PermitAttributeId] );

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestMontrealPermitAttributeAssociation]') AND name = N'PermitRequestMontrealPermitAttributeAssociation.IDX_PermitRequestMontrealPermitAttributeAssociation')
	BEGIN
		DROP INDEX [PermitRequestMontrealPermitAttributeAssociation.IDX_PermitRequestMontrealPermitAttributeAssociation] ON [dbo].[PermitRequestMontrealPermitAttributeAssociation];
	END
GO

ALTER TABLE [dbo].[PermitRequestMontrealPermitAttributeAssociation]
ADD  CONSTRAINT [PK_PermitRequestMontrealPermitAttributeAssociation]
PRIMARY KEY CLUSTERED ([PermitRequestId] , [PermitAttributeId] );

ALTER TABLE [dbo].[LogTemplateWorkAssignment]
ADD CONSTRAINT [PK_LogTemplateWorkAssignment]
PRIMARY KEY CLUSTERED ([LogTemplateId] , [WorkAssignmentId] );

ALTER TABLE [dbo].[DocumentRootPathFunctionalLocation]
ADD CONSTRAINT [PK_DocumentRootPathFunctionalLocation]
PRIMARY KEY CLUSTERED ([DocumentRootPathId] , [FunctionalLocationId] );

ALTER TABLE [dbo].[CokerCardConfigurationWorkAssignment]
ADD CONSTRAINT [PK_CokerCardConfigurationWorkAssignment]
PRIMARY KEY CLUSTERED ([CokerCardConfigurationId] , [WorkAssignmentId] );
GO