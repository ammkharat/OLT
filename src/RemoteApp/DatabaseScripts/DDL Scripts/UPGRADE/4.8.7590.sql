

CREATE TABLE [dbo].[SummaryLogCustomFieldEntryHistoryFlattened] (
	[SummaryLogHistoryId] [bigint] NOT NULL,
	[CustomFields] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS not null,
CONSTRAINT [PK_SummaryLogCustomFieldEntryHistoryFlattened] PRIMARY KEY CLUSTERED 
(
	[SummaryLogHistoryId] ASC
) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

declare @Delimiter varchar(10);
set @Delimiter = '/-^%/';

WITH cte (summaryloghistoryid) as
(
  SELECT DISTINCT summaryloghistoryid FROM SummaryLogCustomFieldEntryHistory
)
insert into SummaryLogCustomFieldEntryHistoryFlattened (SummaryLogHistoryId, CustomFields)
SELECT summaryloghistoryid
, STUFF 
( 
  (SELECT @Delimiter + '^ID:' + CAST(innerLcfeh.Id as varchar(15)) + '^CUSTOMFIELDNAME:' + innerLcfeh.SummaryLogCustomFieldName + '^FIELDENTRY:' + ISNULL(innerLcfeh.FieldEntry, '')
    FROM SummaryLogCustomFieldEntryHistory innerLcfeh
    where innerLcfeh.SummaryLogHistoryId = lcfeh.SummaryLogHistoryId
    order by innerLcfeh.Id
    FOR XML PATH(''), root('MyString'), type
  ).value('/MyString[1]','varchar(max)')
,1,len(@Delimiter),'') as subqueryAsStringList 
FROM cte lcfeh
go

drop table SummaryLogCustomFieldEntryHistory
go

sp_rename 'SummaryLogCustomFieldEntryHistoryFlattened', 'SummaryLogCustomFieldEntryHistory';
go

ALTER TABLE [dbo].[SummaryLogCustomFieldEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldEntryHistory_SummaryLogHistory] FOREIGN KEY([SummaryLogHistoryId])
REFERENCES [dbo].[SummaryLogHistory] ([SummaryLogHistoryId])




GO

