
 --RITM0387753-Shift Handover creation alert(Aarti)
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'ShiftHandoverAlert'
)
begin
alter table [dbo].[SiteConfiguration] Add ShiftHandoverAlert int
end
Go

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'EnableShiftHandoverAlert'
)
begin
alter table [dbo].[SiteConfiguration] Add EnableShiftHandoverAlert bit
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
alter table [dbo].[SiteConfiguration] Add EnableLogsFromOtherUsers bit
end
Go


GO

