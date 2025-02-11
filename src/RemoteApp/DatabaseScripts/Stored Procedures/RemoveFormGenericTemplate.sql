if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveFormGenericTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveFormGenericTemplate]
GO

CREATE Procedure [dbo].[RemoveFormGenericTemplate]
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormGenericTemplate
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id


GO

GRANT EXEC ON RemoveFormGenericTemplate TO PUBLIC
GO

