if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryOnPremiseContractorByOvertimeFormId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryOnPremiseContractorByOvertimeFormId]
GO

CREATE Procedure [dbo].[QueryOnPremiseContractorByOvertimeFormId]
(
	@OvertimeFormId bigint
)
AS
select item.*
from OvertimeFormContractor item
where item.OvertimeFormId = @OvertimeFormId and
      item.Deleted = 0
order by item.Id asc

GRANT EXEC ON [QueryOnPremiseContractorByOvertimeFormId] TO PUBLIC
GO