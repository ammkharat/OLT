IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormOilsandsTrainingItem]') 
         AND name = 'supervisor'
)
begin
alter table [dbo].[FormOilsandsTrainingItem] ADD [supervisor] varchar(100) NULL
end
go
