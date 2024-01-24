IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkPermitForUSPipeline')
	BEGIN
		DROP PROCEDURE [dbo].RemoveWorkPermitForUSPipeline
	END
GO

CREATE Procedure [dbo].[RemoveWorkPermitForUSPipeline]
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE [WorkPermitUSPipeline] 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDate] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
