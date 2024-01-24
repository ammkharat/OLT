if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitMontrealById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitMontrealById]
GO

CREATE Procedure [dbo].[QueryWorkPermitMontrealById]
(
	@Id bigint
)
AS
	SELECT 
		* 
	From 
		WorkPermitMontreal
		INNER JOIN WorkPermitMontrealDetails ON WorkPermitMontreal.Id = WorkPermitMontrealDetails.Id
		LEFT JOIN WorkPermitMontrealRequestDetails  ON WorkPermitMontreal.Id = WorkPermitMontrealRequestDetails.Id
	WHERE
		WorkPermitMontreal.Id = @Id