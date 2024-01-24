if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryOilsandPermitAssessmentByIdAndSiteID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryOilsandPermitAssessmentByIdAndSiteId]
GO

CREATE Procedure [dbo].[QueryOilsandPermitAssessmentByIdAndSiteId]
(
	@Id bigint, @siteid bigint
)
AS
select form.*
from FormPermitAssessment form
where form.Id = @Id and SiteId = @siteid