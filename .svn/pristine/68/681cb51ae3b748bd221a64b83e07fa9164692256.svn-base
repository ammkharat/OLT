IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveSiteCommunication')
	BEGIN
		DROP  Procedure  RemoveSiteCommunication
	END

GO

CREATE Procedure [dbo].RemoveSiteCommunication
	(
		@Id bigint
	)
AS

UPDATE SiteCommunication
SET [Deleted] = 1
WHERE Id = @Id

GO

GRANT EXEC ON RemoveSiteCommunication TO PUBLIC

GO


