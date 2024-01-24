--// Add 3 columns
--// [SiteConfiguration]//----

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'ActionItemFlocLevel'
)
begin
alter table [dbo].SiteConfiguration ADD ActionItemFlocLevel INT NULL	
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'ShiftLogFlocLevel'
)
begin
alter table [dbo].SiteConfiguration ADD ShiftLogFlocLevel INT NULL	
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'ShiftHandoverFlocLevel'
)
begin
alter table [dbo].SiteConfiguration ADD ShiftHandoverFlocLevel INT NULL
end

go
--


GO

