
IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormOilsandsTraining]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormOilsandsTraining] add [siteid] [bigint] NULL
end 
go
IF not EXISTS (select 1 from FormOilsandsTraining where siteid = 3)
begin
update FormOilsandsTraining set siteid = 3 where siteid is null
end 
go

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormOilsandsTrainingByIdAndSiteId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormOilsandsTrainingByIdAndSiteId]
GO

CREATE Procedure [dbo].[QueryFormOilsandsTrainingByIdAndSiteId]
(
	@Id bigint, @siteid bigint
)
AS
select form.*
from FormOilsandsTraining form
where form.Id = @Id and form.siteid = @siteid

GO

