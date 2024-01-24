if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryProcedureDeviationById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryProcedureDeviationById]
GO

CREATE Procedure [dbo].[QueryProcedureDeviationById]
(
	@Id bigint
)
AS
select form.*
from FormProcedureDeviation form
where form.Id = @Id