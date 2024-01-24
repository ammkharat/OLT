IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveSummaryLog')
	BEGIN
		DROP  Procedure  RemoveSummaryLog
	END

GO

CREATE Procedure [dbo].RemoveSummaryLog
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	[SummaryLog] 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveSummaryLog TO PUBLIC

GO