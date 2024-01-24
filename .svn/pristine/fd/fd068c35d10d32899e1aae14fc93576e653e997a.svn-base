SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.df_rename
	(
		@oldname varchar(200),
		@newname varchar(200),
		@tablename varchar(200)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @constraintname VARCHAR(200)
	DECLARE @cmd VARCHAR(1000)
	
	SELECT TOP 1
		@constraintname = c.[name] 
	from 
		sys.objects c, sys.objects t
	where 
		c.parent_object_id = t.object_id and t.name = @tablename
		and c.type = 'D'
		and c.[name] like @oldname + '%'

	SET @cmd = 'EXECUTE sp_rename "dbo.' + @constraintname + '", "' + @newname + '", "Object"'
	EXEC (@cmd)

END
GO

EXEC df_rename 'DF__ActionIte__Delet__', 'DF_ActionItem_Deleted_As_False', 'ActionItem'
EXEC df_rename 'DF__ActionIte__Respo__', 'DF_ActionItem_ResponseReq_As_False', 'ActionItem'
EXEC df_rename 'DF__ActionIte__Sourc__', 'DF_ActionItem_Source_As_Zero', 'ActionItem'

EXEC df_rename 'DF__ActionIte__Activ__', 'DF_ActionItemDef_Active_As_False', 'ActionItemDefinition'
EXEC df_rename 'DF__ActionIte__Delet__', 'DF_ActionItemDef_Deleted_As_False', 'ActionItemDefinition'
EXEC df_rename 'DF__ActionIte__Opera__', 'DF_ActionItemDef_Deleted_As_Zero', 'ActionItemDefinition'
EXEC df_rename 'DF__ActionIte__Prior__', 'DF_ActionItemDef_Priority_As_One', 'ActionItemDefinition'
EXEC df_rename 'DF__ActionIte__Requi__', 'DF_ActionItemDef_ReqApproval_As_False', 'ActionItemDefinition'
EXEC df_rename 'DF__ActionIte__Respo__', 'DF_ActionItemDef_ResponseReq_As_False', 'ActionItemDefinition'
EXEC df_rename 'DF__ActionIte__Sourc__', 'DF_ActionItemDef_Source_As_Zero', 'ActionItemDefinition'

EXEC df_rename 'DF__ActionIte__Activ__', 'DF_ActionItemDefHistory_Active_As_False', 'ActionItemDefinitionHistory'
EXEC df_rename 'DF__ActionIte__Delet__', 'DF_ActionItemDefHistory_Deleted_As_False', 'ActionItemDefinitionHistory'
EXEC df_rename 'DF__ActionIte__Requi__', 'DF_ActionItemDefHistory_ReqApproval_As_False', 'ActionItemDefinitionHistory'
EXEC df_rename 'DF__ActionIte__Respo__', 'DF_ActionItemDefHistory_ResponseReq_As_False', 'ActionItemDefinitionHistory'
EXEC df_rename 'DF__ActionIte__Sourc__', 'DF_ActionItemDefHistory_Source_As_Zero', 'ActionItemDefinitionHistory'
EXEC df_rename 'DF_ActionItemDefinitionHistory_PriorityId', 'DF_ActionItemDefHistory_Priority_As_One', 'ActionItemDefinitionHistory'

EXEC df_rename 'DF__CraftOrTr__Delet__', 'DF_CraftOrTrade_Deleted_As_False', 'CraftOrTrade'

EXEC df_rename 'DF__DailyWork__Confi__', 'DF_DailyWorkAssignment_Confirmed_As_False', 'DailyWorkAssignment'

EXEC df_rename 'DF__Functiona__Delet__', 'DF_FunctionalLocation_Deleted_As_False', 'FunctionalLocation'
EXEC df_rename 'DF__Functiona__OutOf__', 'DF_FunctionalLocation_OutOfService_As_False', 'FunctionalLocation'

EXEC df_rename 'DF__GasTestEl__Stand__', 'DF_GasTestElementInfo_Standard_As_False', 'GasTestElementInfo'

EXEC df_rename 'DF__LiveLinkD__Delet__', 'DF_LiveLinkDocumentLink_Deleted_As_False', 'LiveLinkDocumentLink'

EXEC df_rename 'DF__Log__Deleted__', 'DF_Log_Deleted_As_False', 'Log'
EXEC df_rename 'DF__Log__SourceId__', 'DF_Log_SourceId_As_Zero', 'Log'

EXEC df_rename 'DF__LogAssoci__Delet__', 'DF_LogAssociation_Deleted_As_False', 'LogAssociation'

EXEC df_rename 'DF__LogDefini__Delet__', 'DF_LogDefinition_Deleted_As_False', 'LogDefinition'

EXEC df_rename 'DF__Organizat__Delet__', 'DF_OrganizationalUnit_Deleted_As_False', 'OrganizationalUnit'

EXEC df_rename 'DF__Organizat__Delet__', 'DF_OrganizationalUnitAssignment_Deleted_As_False', 'OrganizationalUnitAssignment'

EXEC df_rename 'DF__SAPNotifi__Proce__', 'DF_SAPNotification_Process_As_Zero', 'SAPNotification'

EXEC df_rename 'DF__SAPShift__Delete__', 'DF_SAPShift_Deleted_As_False', 'SAPShift'

EXEC df_rename 'DF__Schedule__Delete__', 'DF_Schedule_Deleted_As_False', 'Schedule'

EXEC df_rename 'DF__SiteConfi__WorkP__', 'DF_SiteConfigurationSchedule_WorkPermitOptionAutoSelect_As_True', 'SiteConfiguration'

EXEC df_rename 'DF__Tag__Deleted__', 'DF_Tag_Deleted_As_False', 'Tag'

EXEC df_rename 'DF__TargetAle__Requi__', 'DF_TargetAlert_ReqResponse_As_False', 'TargetAlert'

EXEC df_rename 'DF__TargetDef__Delet__', 'DF_TargetDef_Deleted_As_False', 'TargetDefinition'
EXEC df_rename 'DF__TargetDef__Exten__', 'DF_TargetDef_ExtensionParent_As_Null', 'TargetDefinition'
EXEC df_rename 'DF__TargetDef__Gener__', 'DF_TargetDef_GenerateActionItem_As_False', 'TargetDefinition'
EXEC df_rename 'DF__TargetDef__IsAct__', 'DF_TargetDef_IsActive_As_False', 'TargetDefinition'
EXEC df_rename 'DF__TargetDef__Opera__', 'DF_TargetDef_OperationalMode_As_Zero', 'TargetDefinition'
EXEC df_rename 'DF__TargetDef__Prior__', 'DF_TargetDef_PriorityId_As_One', 'TargetDefinition'
EXEC df_rename 'DF__TargetDef__Requi__', 'DF_TargetDef_ReqApproval_As_False', 'TargetDefinition'
EXEC df_rename 'DF__TargetDef__Requi__', 'DF_TargetDef_ReqResponse_As_True', 'TargetDefinition'

EXEC df_rename 'DF_TargetDefinitionHistory_PriorityId', 'DF_TargetDefHistory_PriorityId_As_One', 'TargetDefinitionHistory'

EXEC df_rename 'DF__TargetDef__Delet__', 'DF_TargetDefRWTagConfig_Deleted_As_False', 'TargetDefinitionReadWriteTagConfiguration'

EXEC df_rename 'DF__TargetGap__Mecha__', 'DF_TargetGapReason_Mechanical_As_False', 'TargetGapReason'

EXEC df_rename 'DF__User__Deleted__', 'DF_User_Deleted_As_False', 'User'

DROP Procedure dbo.df_rename
GO
