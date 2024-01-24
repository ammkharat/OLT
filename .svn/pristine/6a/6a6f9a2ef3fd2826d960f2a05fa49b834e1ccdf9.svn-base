if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormOilsandsTrainingHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormOilsandsTrainingHistoryById]
GO

CREATE Procedure [dbo].[QueryFormOilsandsTrainingHistoryById]
(
	@Id bigint
)
AS
select f.*
from FormOilsandsTrainingHistory f
where f.Id = @Id
ORDER BY LastModifiedDateTime