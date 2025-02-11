
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMudsById')
	BEGIN
		DROP Procedure [dbo].QueryWorkPermitMudsById
	END
GO

CREATE Procedure [dbo].[QueryWorkPermitMudsById]
(
	@Id bigint
)
AS
	SELECT 
		* 
	From 
		WorkPermitMuds
		INNER JOIN WorkPermitMudsDetails ON WorkPermitMuds.Id = WorkPermitMudsDetails.Id
		LEFT JOIN WorkPermitMudsRequestDetails  ON WorkPermitMuds.Id = WorkPermitMudsRequestDetails.Id
	WHERE
		WorkPermitMuds.Id = @Id
GO

GRANT EXEC ON QueryWorkPermitMudsById TO PUBLIC
GO
