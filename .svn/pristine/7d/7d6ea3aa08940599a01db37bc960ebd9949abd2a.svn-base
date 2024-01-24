IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveProcedureDeviation')
	BEGIN
		DROP Procedure RemoveProcedureDeviation
	END

GO

CREATE Procedure [dbo].RemoveProcedureDeviation
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE FormProcedureDeviation
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO

GRANT EXEC ON RemoveProcedureDeviation TO PUBLIC
GO