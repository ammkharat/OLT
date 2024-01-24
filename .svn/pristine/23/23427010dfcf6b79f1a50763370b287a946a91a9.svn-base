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