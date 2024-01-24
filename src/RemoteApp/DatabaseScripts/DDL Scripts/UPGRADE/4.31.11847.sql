
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ShiftLogAndSummaryLogMapping]') AND type in (N'U'))

BEGIN
CREATE TABLE [dbo].[ShiftLogAndSummaryLogMapping](
	[SummaryLogId] [bigint] NULL,
	[LogId] [bigint] NULL
) ON [PRIMARY]

END




GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'AllowCustomFieldsToBePartOfAddShiftInfo'
)
begin
alter table [dbo].[SiteConfiguration] Add [AllowCustomFieldsToBePartOfAddShiftInfo] [bit] NOT NULL DEFAULT 0
end
Go





GO

