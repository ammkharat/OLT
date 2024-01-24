if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryOilsandPermitAssessmentById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryOilsandPermitAssessmentById]
GO

CREATE Procedure [dbo].[QueryOilsandPermitAssessmentById]
(
	@Id bigint
)
AS
select form.*
from FormPermitAssessment form
where form.Id = @Id