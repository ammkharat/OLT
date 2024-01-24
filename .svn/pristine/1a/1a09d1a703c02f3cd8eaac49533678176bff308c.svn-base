IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertContractor')
	BEGIN
		DROP Procedure InsertContractor
	END

GO

CREATE Procedure dbo.InsertContractor
	(
	    @Id BIGINT OUTPUT,
		@CompanyName VARCHAR(50),
		@SiteId BIGINT
	)
AS
	INSERT INTO Contractor
	(
	    CompanyName,
	    SiteId
	)
	VALUES
	(
		@CompanyName,
		@SiteId
	)
SET @Id = SCOPE_IDENTITY() 
GO
GRANT EXEC ON InsertContractor TO PUBLIC
GO 