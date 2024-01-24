if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLogDefinitionCustomFieldGroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLogDefinitionCustomFieldGroup]
GO

CREATE Procedure [dbo].[InsertLogDefinitionCustomFieldGroup]
    (
    @LogDefinitionId bigint,
    @CsvCustomFieldGroupIds varchar(max)
    )
AS

INSERT INTO LogDefinitionCustomFieldGroup (LogDefinitionId, CustomFieldGroupId)
SELECT @LogDefinitionId, cfgids.Id
FROM IDSplitter(@CsvCustomFieldGroupIds) cfgids

GO 
GRANT EXEC ON InsertLogDefinitionCustomFieldGroup TO PUBLIC
GO   