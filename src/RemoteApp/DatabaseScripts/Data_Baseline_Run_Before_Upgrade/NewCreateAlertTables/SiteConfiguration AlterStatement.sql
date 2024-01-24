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

 --RITM0387753-Shift Handover creation alert(Aarti)
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'ShiftHandoverAlert'
)
begin
alter table [dbo].[SiteConfiguration] Add ShiftHandoverAlert int NULL DEFAULT 0
end
Go

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'EnableShiftHandoverAlert'
)
begin
alter table [dbo].[SiteConfiguration] Add EnableShiftHandoverAlert bit  NOT NULL DEFAULT 0
end
Go

--RITM0377367-Enable logs from othet users:Aarti
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'EnableLogsFromOtherUsers'
)
begin
alter table [dbo].[SiteConfiguration] Add EnableLogsFromOtherUsers bit  NOT NULL DEFAULT 0
end
Go
--