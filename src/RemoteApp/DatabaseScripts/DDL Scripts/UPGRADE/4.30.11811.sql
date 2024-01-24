IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Restrictionlocation]') 
         AND name = 'SiteID'
)
begin
alter table [dbo].[Restrictionlocation] Add [SiteID] bigint
end
Go

update Restrictionlocation set SiteID = 3 where SiteID is null



GO




GO

