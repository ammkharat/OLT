IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveContractor')
	BEGIN
		DROP Procedure RemoveContractor
	END

GO

CREATE Procedure [dbo].RemoveContractor
	(
		@Id BIGINT
	)
AS
	DELETE FROM Contractor WHERE Id = @Id
GO
