if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormOilsandsTrainingItemByFormOilsandsTrainingId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormOilsandsTrainingItemByFormOilsandsTrainingId]
GO

CREATE Procedure [dbo].[QueryFormOilsandsTrainingItemByFormOilsandsTrainingId]
(
	@FormOilsandsTrainingId bigint
)
AS
select item.*
from FormOilsandsTrainingItem item
where item.FormOilsandsTrainingId = @FormOilsandsTrainingId and
      item.Deleted = 0
order by item.Id asc

GRANT EXEC ON [QueryFormOilsandsTrainingItemByFormOilsandsTrainingId] TO PUBLIC
GO