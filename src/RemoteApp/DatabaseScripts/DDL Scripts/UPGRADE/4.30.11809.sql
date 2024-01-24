IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[RestrictionReasonCode]') 
         AND name = 'SiteID'
)
begin
alter table [dbo].[RestrictionReasonCode] Add [SiteID] bigint
end
Go

update RestrictionReasonCode set SiteID = 3 where SiteID is null



GO

