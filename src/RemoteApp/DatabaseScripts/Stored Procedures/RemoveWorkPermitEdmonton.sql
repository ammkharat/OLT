IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkPermitEdmonton')
	BEGIN
		DROP  Procedure  RemoveWorkPermitEdmonton
	END

GO

CREATE Procedure [dbo].RemoveWorkPermitEdmonton
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE WorkPermitEdmonton
SET LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime,
	Deleted = 1
WHERE Id = @Id
GO


GRANT EXEC ON RemoveWorkPermitEdmonton TO PUBLIC

GO