exec sp_rename 'SummaryLogCustomFieldGroup',  'CustomFieldGroup'

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSummaryLogCustomFieldGroup')
	BEGIN
		DROP  Procedure  InsertSummaryLogCustomFieldGroup
	END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogCustomFieldByWorkAssignment')
    BEGIN
        DROP  Procedure  [dbo].QuerySummaryLogCustomFieldByWorkAssignment
    END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogCustomFieldGroupBySiteId')
	BEGIN
		DROP  Procedure  QuerySummaryLogCustomFieldGroupBySiteId
	END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSummaryLogCustomFieldGroup')
	BEGIN
		DROP  Procedure  UpdateSummaryLogCustomFieldGroup
	END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteSummaryLogCustomFieldGroup')
	BEGIN
		DROP  Procedure  DeleteSummaryLogCustomFieldGroup
	END

GO

exec sp_rename 'SummaryLogCustomFieldGroupWorkAssignment',  'CustomFieldGroupWorkAssignment'

GO

exec sp_RENAME 'CustomFieldGroupWorkAssignment.SummaryLogCustomFieldGroupId', 'CustomFieldGroupId', 'COLUMN'

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSummaryLogCustomFieldGroupWorkAssignment')
	BEGIN
		DROP  Procedure  InsertSummaryLogCustomFieldGroupWorkAssignment
	END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogCustomFieldGroupWorkAssignmentByGroupId')
	BEGIN
		DROP  Procedure  QuerySummaryLogCustomFieldGroupWorkAssignmentByGroupId
	END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteSummaryLogCustomFieldGroupWorkAssignmentByGroupId')
	BEGIN
		DROP  Procedure  DeleteSummaryLogCustomFieldGroupWorkAssignmentByGroupId
	END

GO

exec sp_rename 'SummaryLogCustomField',  'CustomField'

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogCustomFieldByGroupId')
	BEGIN
		DROP  Procedure  QuerySummaryLogCustomFieldByGroupId
	END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSummaryLogCustomField')
	BEGIN
		DROP  Procedure  InsertSummaryLogCustomField
	END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteSummaryLogCustomFieldByGroupId')
	BEGIN
		DROP  Procedure  DeleteSummaryLogCustomFieldByGroupId
	END

GO

exec sp_RENAME 'CustomField.SummaryLogCustomFieldGroupId', 'CustomFieldGroupId', 'COLUMN'



GO
