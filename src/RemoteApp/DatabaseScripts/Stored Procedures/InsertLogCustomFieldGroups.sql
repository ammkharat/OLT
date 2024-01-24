if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLogCustomFieldGroups]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLogCustomFieldGroups]
GO

CREATE Procedure [dbo].[InsertLogCustomFieldGroups]
    (
    @LogId bigint,
	@CsvCustomFieldGroupIds varchar(max)
    )
AS

INSERT INTO LogCustomFieldGroup (LogId, CustomFieldGroupId)
SELECT @LogId, cfgids.Id
FROM IDSplitter(@CsvCustomFieldGroupIds) cfgids

GO 
GRANT EXEC ON InsertLogCustomFieldGroups TO PUBLIC
GO   