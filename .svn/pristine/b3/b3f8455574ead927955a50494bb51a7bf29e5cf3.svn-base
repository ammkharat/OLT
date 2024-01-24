IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateContractor')
	BEGIN
		DROP  Procedure  UpdateContractor
	END

GO

CREATE Procedure [dbo].UpdateContractor
	(
	    @Id BIGINT,
		@CompanyName VARCHAR(50),
		@SiteId BIGINT
	)

AS
	UPDATE Contractor 
	SET 
	    CompanyName = @CompanyName, 
	    SiteId = @SiteId 
	WHERE Id = @Id
GO


