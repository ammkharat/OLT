if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormOilsandsTrainingById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormOilsandsTrainingById]
GO

CREATE Procedure [dbo].[QueryFormOilsandsTrainingById]
(
	@Id bigint
)
AS
select form.*
from FormOilsandsTraining form
where form.Id = @Id