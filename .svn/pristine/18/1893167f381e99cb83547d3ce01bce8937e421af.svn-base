

CREATE TABLE [dbo].[LogDefinitionCustomFieldEntryHistoryFlattened] (
	[LogDefinitionHistoryId] [bigint] NOT NULL,
	[CustomFields] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS not null,
CONSTRAINT [PK_LogDefinitionCustomFieldEntryHistoryFlattened] PRIMARY KEY CLUSTERED 
(
	[LogDefinitionHistoryId] ASC
) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

declare @Delimiter varchar(10);
set @Delimiter = '/-^%/';

WITH cte (LogDefinitionHistoryId) as
(
  SELECT DISTINCT LogDefinitionHistoryId FROM LogDefinitionCustomFieldEntryHistory
)
insert into LogDefinitionCustomFieldEntryHistoryFlattened (LogDefinitionHistoryId, CustomFields)
SELECT lcfeh.LogDefinitionHistoryId
, STUFF 
( 
  (SELECT @Delimiter + '^ID:' + CAST(innerLcfeh.Id as varchar(15)) + '^CUSTOMFIELDNAME:' + innerLcfeh.CustomFieldName + '^FIELDENTRY:' + ISNULL(innerLcfeh.FieldEntry, '')
    FROM LogDefinitionCustomFieldEntryHistory innerLcfeh
    where innerLcfeh.LogDefinitionHistoryId = lcfeh.LogDefinitionHistoryId
    order by innerLcfeh.Id
    FOR XML PATH(''), root('MyString'), type
  ).value('/MyString[1]','varchar(max)')
,1,len(@Delimiter),'') as subqueryAsStringList 
FROM cte lcfeh

go

drop table LogDefinitionCustomFieldEntryHistory
go

sp_rename 'LogDefinitionCustomFieldEntryHistoryFlattened', 'LogDefinitionCustomFieldEntryHistory';
go

ALTER TABLE [dbo].[LogDefinitionCustomFieldEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionCustomFieldEntryHistory_LogDefinitionHistory] FOREIGN KEY([LogDefinitionHistoryId])
REFERENCES [dbo].[LogDefinitionHistory] ([LogDefinitionHistoryId])




GO

