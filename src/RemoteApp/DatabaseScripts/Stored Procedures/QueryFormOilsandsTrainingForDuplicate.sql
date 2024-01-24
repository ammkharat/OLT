if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormOilsandsTrainingForDuplicate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormOilsandsTrainingForDuplicate]
GO

CREATE Procedure [dbo].[QueryFormOilsandsTrainingForDuplicate]
(
	@TrainingDate date,
	@ShiftId bigint,
	@WorkAssignmentId bigint,
	@CurrentUserId bigint
)
AS
select TOP 1 form.*
from FormOilsandsTraining form
where form.TrainingDate = @TrainingDate and
	  form.ShiftId = @ShiftId and
	  ((@WorkAssignmentId is null and form.WorkAssignmentId is null) OR (form.WorkAssignmentId = @WorkAssignmentId)) and
	  form.CreatedByUserId = @CurrentUserId and
	  form.Deleted = 0
