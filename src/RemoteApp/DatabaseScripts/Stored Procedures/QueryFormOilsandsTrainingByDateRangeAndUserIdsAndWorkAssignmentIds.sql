if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormOilsandsTrainingByDateRangeAndUserIdsAndWorkAssignmentIds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormOilsandsTrainingByDateRangeAndUserIdsAndWorkAssignmentIds]
GO

CREATE Procedure [dbo].[QueryFormOilsandsTrainingByDateRangeAndUserIdsAndWorkAssignmentIds]
(
	@CsvUserIds VARCHAR(MAX),
	@CsvWorkAssignmentIds VARCHAR(MAX),
	@StartOfDateRange date,
    @EndOfDateRange date	
)
AS
select form.*
from FormOilsandsTraining form
inner join IDSplitter(@CsvWorkAssignmentIds) waids on waids.Id = form.WorkAssignmentId
inner join IDSplitter(@CsvUserIds) userids on userids.Id = form.CreatedByUserId
inner join [User] u on form.CreatedByUserId = u.Id
inner join WorkAssignment wa on form.WorkAssignmentId = wa.Id
where 
form.TrainingDate <= @EndOfDateRange 
and form.TrainingDate >= @StartOfDateRange
and form.Deleted = 0
order by u.Lastname, u.Firstname, wa.Name, form.TrainingDate, form.Id