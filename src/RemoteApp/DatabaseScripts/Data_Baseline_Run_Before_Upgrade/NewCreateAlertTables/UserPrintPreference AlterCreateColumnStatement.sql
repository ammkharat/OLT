--// Add 1 columns
--// [UserPrintPreference]//----


--RITM0387753-Shift Handover creation alert-UserPreference(Aarti)
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[UserPrintPreference]') 
         AND name = 'ShowShifthandoverAlertDialog'
)
begin
alter table [dbo].[UserPrintPreference] Add ShowShifthandoverAlertDialog bit  NOT NULL DEFAULT 0
end
Go
--