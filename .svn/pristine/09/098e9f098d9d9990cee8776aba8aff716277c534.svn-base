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


