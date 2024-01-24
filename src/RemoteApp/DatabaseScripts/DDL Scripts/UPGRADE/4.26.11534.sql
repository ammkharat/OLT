IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormOilsandsTrainingItem]') 
         AND name = 'Supervisor'
)
begin
alter table [dbo].[FormOilsandsTrainingItem] ADD Supervisor VARCHAR(100) 
end
go



GO

