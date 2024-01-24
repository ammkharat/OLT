IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormLubesCsd')
	BEGIN
		DROP  Procedure  RemoveFormLubesCsd
	END

GO

CREATE Procedure [dbo].RemoveFormLubesCsd
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormLubesCsd
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveFormLubesCsd TO PUBLIC

GO