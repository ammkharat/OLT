

CREATE TABLE [dbo].[LogCustomFieldEntryHistoryFlattened] (
	[LogHistoryId] [bigint] NOT NULL,
	[CustomFields] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS not null,
CONSTRAINT [PK_LogCustomFieldEntryHistoryFlattened] PRIMARY KEY CLUSTERED 
(
	[LogHistoryId] ASC
) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

declare @Delimiter varchar(10);
set @Delimiter = '/-^%/';

WITH cte (loghistoryid) as
(
  SELECT DISTINCT LogHistoryId FROM LogCustomFieldEntryHistory
)
insert into LogCustomFieldEntryHistoryFlattened (LogHistoryId, CustomFields)
SELECT lcfeh.loghistoryid
, STUFF 
( 
  (SELECT @Delimiter + '^ID:' + CAST(innerLcfeh.Id as varchar(15)) + '^CUSTOMFIELDNAME:' + innerLcfeh.CustomFieldName + '^FIELDENTRY:' + ISNULL(innerLcfeh.FieldEntry, '')
    FROM LogCustomFieldEntryHistory innerLcfeh
    where innerLcfeh.LogHistoryId = lcfeh.LogHistoryId
    order by innerLcfeh.Id
    FOR XML PATH(''), root('MyString'), type
  ).value('/MyString[1]','varchar(max)')
,1,len(@Delimiter),'') as subqueryAsStringList 
FROM CTE lcfeh
go


drop table LogCustomFieldEntryHistory
go

sp_rename 'LogCustomFieldEntryHistoryFlattened', 'LogCustomFieldEntryHistory';
go

ALTER TABLE [dbo].[LogCustomFieldEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_LogCustomFieldEntryHistory_LogHistory] FOREIGN KEY([LogHistoryId])
REFERENCES [dbo].[LogHistory] ([LogHistoryId])
GO