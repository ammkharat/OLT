IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkPermitLubes')
	BEGIN
		DROP  Procedure  RemoveWorkPermitLubes
	END

GO

CREATE Procedure [dbo].RemoveWorkPermitLubes
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE WorkPermitLubes
SET LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime,
	Deleted = 1
WHERE Id = @Id
GO


GRANT EXEC ON RemoveWorkPermitLubes TO PUBLIC

GO