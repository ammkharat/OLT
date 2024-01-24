if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertSummaryLogCustomFieldGroups]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertSummaryLogCustomFieldGroups]
GO

CREATE Procedure [dbo].[InsertSummaryLogCustomFieldGroups]
    (
    @SummaryLogId bigint,
	@CsvCustomFieldGroupIds varchar(max)
    )
AS

INSERT INTO SummaryLogCustomFieldGroup (SummaryLogId, CustomFieldGroupId)
SELECT @SummaryLogId, cfgids.Id
FROM IDSplitter(@CsvCustomFieldGroupIds) cfgids

GO 
GRANT EXEC ON InsertSummaryLogCustomFieldGroups TO PUBLIC
GO   